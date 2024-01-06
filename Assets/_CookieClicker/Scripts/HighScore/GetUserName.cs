using Oculus.Platform;
using Oculus.Platform.Models;

public class GetUserName
{
    public string UserName()
    {
        Users.GetLoggedInUser().OnComplete(GetLoggedInUserCallback);
        return string.Empty;
    }
    private void GetLoggedInUserCallback(Message msg)
    {
        if (!msg.IsError)
        {
            User user = msg.GetUser();
            string userName = user.OculusID;
            string displayName = user.DisplayName;
        }
    }
}
