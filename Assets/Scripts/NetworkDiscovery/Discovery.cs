using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class Discovery : NetworkDiscovery
{

	private GameObject _mainMenuGameObject;

	private MainMenu _mainMenuScript;
	
	private float timeout = 5f;

	private Dictionary<IPAddress, float> lanAddresses = new Dictionary<IPAddress, float>();

	private void Awake()
	{
		Initialize();
		StartAsClient();
		StartCoroutine(CleanupExpiredEntries());
	}

	private void Start()
	{
		if (isServer)
			StopBroadcast();
		_mainMenuGameObject = GameObject.Find("EventSystem");
		_mainMenuScript = _mainMenuGameObject.GetComponent<MainMenu>();
	}

	public void StartBroadcast()
	{
		StopBroadcast();
		Initialize();
		StartAsServer();
	}

	private IEnumerator CleanupExpiredEntries()
	{
		while(true)
		{
			bool changed = false;

			var keys = lanAddresses.Keys.ToList();
			foreach (var key in keys)
			{
				if(lanAddresses[key] <= Time.time)
				{
					lanAddresses.Remove(key);
					changed = true;
				}
			}
			if(changed)
				UpdateMatchInfos();

			yield return new WaitForSeconds(timeout);
		}
	}

	public override void OnReceivedBroadcast(string fromAddress, string data)
	{
		base.OnReceivedBroadcast(fromAddress, data);

		IPAddress info = new IPAddress(fromAddress, data);

		bool found = false;
		foreach (var ip in lanAddresses)
		{
			if (ip.Key.ipAddress == info.ipAddress)
			{
				found = true;
				info = ip.Key;
				break;
			}
		}
		if(!found)
		{
			lanAddresses.Add(info, Time.time + timeout);
			UpdateMatchInfos();
		}
		else
		{
			lanAddresses[info] = Time.time + timeout;
		}
	}

	private void UpdateMatchInfos()
	{
		//GameListController.AddLanMatches(lanAddresses.Keys.ToList());
		_mainMenuScript.ServersListNew(lanAddresses);
		foreach (var x in lanAddresses.Keys.ToList())
		{
			Debug.Log($"Ip: {x.ipAddress} -> Name: {x.name}");
		}
	}
}