using Oculus.Platform;
using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    GetUserName oculusUserName = new GetUserName();
    string appId = "24602120609403423";
    void Start()
    {
        //StartCoroutine(init());
        //Debug.Log(Oculus.Platform.Core.IsInitialized());
    }

    // Update is called once per frame
    IEnumerator init()
    {
        Core.Initialize(appId);
        while (!Core.IsInitialized())
        {
            yield return null;
        }
        Debug.Log(oculusUserName.UserName());
        WriteEntry();
    }
    void WriteEntry()
    {
        Leaderboards.WriteEntry("Weekly", 10);
    }
}
