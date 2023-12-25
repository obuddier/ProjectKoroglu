using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject Levels_Panel;
    public GameObject Buttons_Panel;
    public GameObject Pause_Panel;
    public GameObject Pause_Levels_Panel;
    public GameObject Pause_Buttons_Panel;
    public GameObject Star_Panel;
    public CharacterMovement characterMovement;

    StarPanel starPanel;

    void Start()
    {
        starPanel = FindObjectOfType<StarPanel>();
        GameOverPanel.SetActive(false);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Pause_Buttons_Panel.SetActive(false);
        Pause_Levels_Panel.SetActive(false);
        Pause_Panel.SetActive(false);
        Star_Panel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && characterMovement.amDead == false)
        {
            Pause_Panel.SetActive(true);
            Pause_Buttons_Panel.SetActive(true); // Esc tuşuna basıldığında panelin açılmasını sağlar
            Time.timeScale = 0;
            GameOverPanel.SetActive(false);
            Buttons_Panel.SetActive(false);
            Levels_Panel.SetActive(false);
            Pause_Levels_Panel.SetActive(false);
            Star_Panel.SetActive(false);
        }
    }
    public void Open_Levels_Panel()
    {
        GameOverPanel.SetActive(true);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(true);
        Pause_Buttons_Panel.SetActive(false);
        Pause_Levels_Panel.SetActive(false);
        Pause_Panel.SetActive(false);
        Star_Panel.SetActive(false);
    }

    public void GetBackToGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        Buttons_Panel.SetActive(true);
        Levels_Panel.SetActive(false);
        Pause_Buttons_Panel.SetActive(false);
        Pause_Levels_Panel.SetActive(false);
        Pause_Panel.SetActive(false);
        Star_Panel.SetActive(false);
    }

    public void PausePanel()
    {
        Pause_Panel.SetActive(true);
        Pause_Buttons_Panel.SetActive(true);
        Pause_Levels_Panel.SetActive(false);
        GameOverPanel.SetActive(false);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Star_Panel.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Pause_Buttons_Panel.SetActive(false);
        Pause_Levels_Panel.SetActive(false);
        Pause_Panel.SetActive(false);
        Star_Panel.SetActive(false);

    }


    public void GetBackToPausePanel()
    {
        GameOverPanel.SetActive(false);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Pause_Buttons_Panel.SetActive(true);
        Pause_Levels_Panel.SetActive(false);
        Pause_Panel.SetActive(true);
        Star_Panel.SetActive(false);
    }

    public void Open_Levels_ForPause_Panel()
    {
        GameOverPanel.SetActive(false);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Pause_Buttons_Panel.SetActive(false);
        Pause_Levels_Panel.SetActive(true);
        Pause_Panel.SetActive(true);
        Star_Panel.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Star_Panel_Open()
    {
        GameOverPanel.SetActive(false);
        Buttons_Panel.SetActive(false);
        Levels_Panel.SetActive(false);
        Pause_Buttons_Panel.SetActive(false);
        Pause_Levels_Panel.SetActive(false);
        Pause_Panel.SetActive(false);
        Star_Panel.SetActive(true);
        starPanel.KillCount();
        Time.timeScale = 0;
    }
}
