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
        print("Giriþ baþarýlý/Hesap oluþturuldu!");
    }

    void OnError(PlayFabError error)
    {
        print("Giriþ yapýlýrken/hesap oluþturulurken hata oluþtu");
        print(error.GenerateErrorReport());
    }
        
        
}
