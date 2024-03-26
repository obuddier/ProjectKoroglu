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
    public GameObject Options_Panel;
    public GameObject Sound_Panel;
    public GameObject Levels_Panel;
    public GameObject Level_Hardness_Panel;
    public GameObject Score_Panel;
    public GameObject First_Menu_Buttons;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Time.timeScale = 1f;
            
            Options_Panel.SetActive(true);
            First_Menu_Buttons.SetActive(false);
            Buttons.SetActive(false);
            loginUI.SetActive(false);
            registerUI.SetActive(false);
            Sound_Panel.SetActive(true);
            Levels_Panel.SetActive(false);
            Level_Hardness_Panel.SetActive(false);
            Score_Panel.SetActive(false);
            


            Options_Panel.SetActive(false);
            Buttons.SetActive(true);
            loginUI.SetActive(false);
            registerUI.SetActive(false);
            Sound_Panel.SetActive(false);
            Levels_Panel.SetActive(false);
            Level_Hardness_Panel.SetActive(false);
            Score_Panel.SetActive(false);
            First_Menu_Buttons.SetActive(false);
            // Optionsssssssss();
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    // public void Optionsssssssss()
    // {
    //     Options_Panel.SetActive(true);
    //     First_Menu_Buttons.SetActive(false);
    //     Buttons.SetActive(false);
    //     loginUI.SetActive(false);
    //     registerUI.SetActive(false);
    //     Sound_Panel.SetActive(true);
    //     Levels_Panel.SetActive(false);
    //     Level_Hardness_Panel.SetActive(false);
    //     Score_Panel.SetActive(false);
        


    //     Options_Panel.SetActive(false);
    //     Buttons.SetActive(true);
    //     loginUI.SetActive(false);
    //     registerUI.SetActive(false);
    //     Sound_Panel.SetActive(false);
    //     Levels_Panel.SetActive(false);
    //     Level_Hardness_Panel.SetActive(false);
    //     Score_Panel.SetActive(false);
    //     First_Menu_Buttons.SetActive(false);
    // }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        Options_Panel.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(true);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(false);
        First_Menu_Buttons.SetActive(false);
    }
    public void RegisterScreen() // Register button
    {
        Options_Panel.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(true);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(false);
        First_Menu_Buttons.SetActive(false);
    }

    public void MainMenuBtn() // Register button
    {
        Options_Panel.SetActive(false);
        Buttons.SetActive(true);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(false);
        First_Menu_Buttons.SetActive(false);
    }

    public void Options()
    {
        Options_Panel.SetActive(true);
        First_Menu_Buttons.SetActive(true);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(false);
    }

    public void Sound()
    {
        Options_Panel.SetActive(true);
        First_Menu_Buttons.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(true);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(false);
    }

    public void Levels()
    {
        Options_Panel.SetActive(true);
        First_Menu_Buttons.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(true);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(false);
    }

    public void Level_Hardness()
    {
        Options_Panel.SetActive(true);
        First_Menu_Buttons.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(true);
        Score_Panel.SetActive(false);
    }

    public void Score()
    {
        Options_Panel.SetActive(true);
        First_Menu_Buttons.SetActive(false);
        Buttons.SetActive(false);
        loginUI.SetActive(false);
        registerUI.SetActive(false);
        Sound_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Level_Hardness_Panel.SetActive(false);
        Score_Panel.SetActive(true);
    }

}
