using System;
using System.Collections.Generic;
using MLAPI;
using MLAPI.SceneManagement;
using MLAPI.Transports.UNET;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : NetworkBehaviour
{
    [SerializeField] public GameObject inputPanel;
    [SerializeField] public Text inputPanelButtonText;
    [SerializeField] public InputField inputPanelInputField;
    
    [SerializeField] public GameObject networkDiscoveryObject;

    [SerializeField] public GameObject serversListPanel;
    [SerializeField] public Transform serversListButton;
    [SerializeField] public Transform serversListContentHolder;
    private Discovery _networkDiscoveryScript;
    private bool _asHost;

    private bool _discoverySystemEnabled = false;

    private void Start()
    {
        if(_discoverySystemEnabled)
            _networkDiscoveryScript = networkDiscoveryObject.GetComponent<Discovery>();
        if(IsServer)
            NetworkManager.Singleton.StopServer();
        if(IsClient)
            NetworkManager.Singleton.StopClient();
    }

    public void Join()
    {
        inputPanelButtonText.text = "[ JOIN [";
        inputPanel.SetActive(true);
        _asHost = false;
    }
    
    public void Host()
    {
        //SceneManager.LoadScene("Hosting");
        inputPanelButtonText.text = "[ START [";
        inputPanel.SetActive(true);
        _asHost = true;
    }

    public void Back()
    {
        inputPanel.SetActive(false);
        serversListPanel.SetActive(false);
    }

    public void HostJoin()
    {
        if (inputPanelInputField.text.Length < 1) return;
        UserSettings.Name = inputPanelInputField.text;
        if (_asHost)
        {
            if (_discoverySystemEnabled)
            {
                _networkDiscoveryScript.broadcastData = inputPanelInputField.text;
                _networkDiscoveryScript.StartBroadcast();
            }

            NetworkManager.Singleton.StartHost();
            return;
        }

        if (_discoverySystemEnabled)
        {
            ServersList();
            return;
        }
        JoinServer("127.0.0.1");
    }

    public void ServersList()
    {
        serversListPanel.SetActive(true);
    }

    public void ServersListNew(Dictionary<IPAddress, float> servers)
    {
        foreach (Transform child in serversListContentHolder) {
            Destroy(child.gameObject);
        }

        foreach (var server in servers)
        {
            var newButton = Instantiate(serversListButton, serversListContentHolder);
            string ip = server.Key.ipAddress;
            newButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { JoinServer(ip); });
            newButton.gameObject.GetComponentInChildren<Text>().text = server.Key.name;
        }
    }


    private void JoinServer(string ip)
    {
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ip;
        NetworkManager.Singleton.StartClient();
        Debug.Log("Trying to join " + ip);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
