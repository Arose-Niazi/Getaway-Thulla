using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.SceneManagement;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostingConnectionHandle : NetworkBehaviour
{
    public static bool AllowConnections;
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Singleton.OnServerStarted += HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback += HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += HandleClientDisconnect;


        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if(IsServer)
                NetworkManager.StopHost();
            if(IsClient)
                NetworkManager.StopClient();
        }

        
        if (IsServer)
        {
            if (SceneManager.GetActiveScene().name == "Hosting")
            {
                AllowConnections = true;
                UserSettings.ConnectedClients = new Dictionary<ulong, string>();
                //UserSettings.ConnectedClients.Add(OwnerClientId, UserSettings.Name);
                GetEveryoneNamesClientRpc();
            }
        }
    }
    
    private void NetworkSceneManagerOnOnSceneSwitched()
    {
        
    }

    private void HandleServerStarted()
    {
        Debug.Log("Handle Server Started");
        NetworkSceneManager.SwitchScene("Hosting");
        AllowConnections = true;
    }

    private void HandleClientConnected(ulong clientId)
    {
        Debug.Log("Handle Client Connected");
        if (IsServer)
        {
            StartCoroutine(DelayPlayerNameGet(clientId));
        }
    }
    

    private void HandleClientDisconnect(ulong clientId)
    {
        Debug.Log("Handle Client Disconnect");
        if (IsServer)
            JustLeftServerRpc(clientId);
    }

    IEnumerator DelayPlayerNameGet(ulong clientId)
    {
        yield return new WaitForSeconds(1);
        GetMyNameClientRpc(clientId);
    }
    
    
    private void SendTheNamesList()
    {
        NamesListStartClientRpc();
        foreach (var client in UserSettings.ConnectedClients)
        {
            NamesListClientRpc(client.Key, client.Value);
        }
        NamesListEndClientRpc();
    }
    

    [ServerRpc(RequireOwnership = false)]
    private void JustJoinedServerRpc(ulong clientId, string playerName)
    {
        if(UserSettings.ConnectedClients.ContainsKey(clientId)) return;
        UserSettings.ConnectedClients.Add(clientId, playerName);
        SendTheNamesList();
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void JustLeftServerRpc(ulong clientId)
    {
        UserSettings.ConnectedClients.Remove(clientId);
        SendTheNamesList();
    }

    [ClientRpc]
    private void GetEveryoneNamesClientRpc()
    {
        JustJoinedServerRpc(OwnerClientId, UserSettings.Name);
    }

    [ClientRpc]
    private void NamesListStartClientRpc()
    {
        UserSettings.ConnectedClients = new Dictionary<ulong, string>();
    }
    
    [ClientRpc]
    private void NamesListClientRpc(ulong id, string playerName)
    {
        UserSettings.ConnectedClients.Add(id, playerName);
        UserSettings.UpdatedNamesList = true;
    }
    
    [ClientRpc]
    private void NamesListEndClientRpc()
    {
        UserSettings.UpdatedNamesList = true;
    }

    [ClientRpc]
    private void GetMyNameClientRpc(ulong clientId)
    {
        if (clientId != NetworkManager.Singleton.LocalClientId) return;
        JustJoinedServerRpc(clientId, UserSettings.Name);
    }
    
    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null) { return; }

        NetworkManager.Singleton.OnServerStarted -= HandleServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= HandleClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= HandleClientDisconnect;
        NetworkSceneManager.OnSceneSwitched -= NetworkSceneManagerOnOnSceneSwitched;
    }
}
