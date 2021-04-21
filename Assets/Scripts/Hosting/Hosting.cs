using System;
using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.Messaging;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hosting : NetworkBehaviour
{
    [SerializeField] public Button[] players;
    [SerializeField] public GameObject startButton;

    private Text[] _playersName;

    public void Start()
    {
        _playersName = new Text[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            _playersName[i] = players[i].GetComponentInChildren<Text>();
        }

        foreach (var button in players)
        {
            if (!IsServer)
                button.interactable = false;
            button.gameObject.SetActive(false);
        }
        
        startButton.SetActive(IsServer);
        players[0].interactable = false;

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        Debug.Log("Start Game Pressed");
    }

    public void KickPlayer(ulong clientId)
    {
        Debug.Log("Kick Player " + clientId);
        KickedClientRpc(clientId);
    }

    [ClientRpc]
    private void KickedClientRpc(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
            SceneManager.LoadScene("MainMenu");
    }
    

    private void LateUpdate()
    {
        if (UserSettings.UpdatedNamesList)
        {
            UserSettings.UpdatedNamesList = false;

            foreach (var button in players)
            {
                button.gameObject.SetActive(false);
            }
            
            foreach (var client in UserSettings.ConnectedClients)
            {
                var buttonLoc = 0;
                if (client.Key > 0)
                    buttonLoc = ((int) client.Key) - 1;
                _playersName[buttonLoc].text = client.Value;
                players[buttonLoc].gameObject.SetActive(true);
                var clientId = client.Key;
                players[buttonLoc].onClick.AddListener(delegate { KickPlayer(clientId); });
            }
        }
    }
}
