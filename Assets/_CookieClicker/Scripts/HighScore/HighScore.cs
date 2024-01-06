using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    GetUserName oculusUserName = new GetUserName();
    void Start()
    {
#if !UNITY_EDITOR
        Debug.Log(oculusUserName.UserName());
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
