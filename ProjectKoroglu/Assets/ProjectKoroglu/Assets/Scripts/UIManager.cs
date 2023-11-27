using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject Buttons;
    public GameObject SoundOptions;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        SoundOptions.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }
    public void RegisterScreen() // Register button
    {
        SoundOptions.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }

    public void MainMenuBtn() // Register button
    {
        SoundOptions.SetActive(false);
        Buttons.SetActive(true);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
    }

    public void Options()
    {
        SoundOptions.SetActive(true);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
    }
}
