using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hosting : MonoBehaviour
{
    [SerializeField] public Button[] players;

    private Text[] _playersName;

    public void Start()
    {
        _playersName = new Text[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            _playersName[i] = players[i].GetComponentInChildren<Text>();
        }

        _playersName[2].text = "New Player";
        Debug.Log(_playersName[3].text);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        Debug.Log("Start Game Pressed");
    }

    public void KickPlayer(int value)
    {
        Debug.Log("Kick Player " + value);
    }
}
