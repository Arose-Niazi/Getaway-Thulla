using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettings : MonoBehaviour
{

    public static string Name;
    
    public static Dictionary<ulong, string> ConnectedClients = new Dictionary<ulong, string>();
    public static bool UpdatedNamesList = false;
}
