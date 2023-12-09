using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Diagnostics;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

    }

    void OnSuccess(LoginResult result)
    {
        print("Giri� ba�ar�l�/Hesap olu�turuldu!");
    }

    void OnError(PlayFabError error)
    {
        print("Giri� yap�l�rken/hesap olu�turulurken hata olu�tu");
        print(error.GenerateErrorReport());
    }
        
        
}
