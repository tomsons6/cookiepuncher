using Oculus.Platform;
using Oculus.Platform.Models;
using UnityEngine;

public class GetUserName
{
    string userName;
    string displayName;
    public string UserName()
    {
        Users.GetLoggedInUser().OnComplete(GetLoggedInUserCallback);
        return userName;
    }
    private void GetLoggedInUserCallback(Message msg)
    {
        if (!msg.IsError)
        {
            Debug.Log("Logine success - " + msg + "; - message type - " + msg.Type); 
            User user = msg.GetUser();
            Debug.Log("oculusID - " + user.OculusID);
            Debug.Log("displayname - " + user.DisplayName);
            userName = user.OculusID;
            displayName = user.DisplayName;
        }
        else 
        {
            Debug.Log(msg.GetError().Message);
        }
    }
}
