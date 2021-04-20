using UnityEngine;

public class IPAddress
{
	public string ipAddress { get; }
	public string name { get; }

	public IPAddress(string fromAddress, string data)
	{
		ipAddress = fromAddress.Substring(fromAddress.LastIndexOf(":") + 1, fromAddress.Length - (fromAddress.LastIndexOf(":") + 1));
		name = data;
	}
}