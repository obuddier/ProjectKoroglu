using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLockManager : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    public HealthBar healthBar;
    public ScoreManager scoreManager;
    private int unlockedLevels;
    public CharacterMovement characterMovement;

    // public void Start()
    // {
    //     scoreManager = GetComponent<ScoreManager>();
    // }
    public void Update()
    {
        // En son oynanan seviyenin değerini al
        unlockedLevels = PlayerPrefs.GetInt("unlockedLevels", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevels; i++)
        {
            buttons[i].interactable = true;
        }

        // En son oynanan seviyenin Debug.Log çıktısı olarak gösterilmesi
        // Debug.Log("En son oynanan level: " + (unlockedLevels));
    }

    public void LoadtheLevel(int levelIndex)
    {
        healthBar.ResetHealthForNewLevel();
        characterMovement.currentHealth = 100;
        PlayerPrefs.SetInt("Level" + (levelIndex) + "Score", 0);
        // scoreManager.levelScores[scoreManager.currentLevel - 1] = 0;
        // Debug.Log(scoreManager.levelScores[scoreManager.currentLevel - 1]);
        SceneManager.LoadScene(levelIndex);
    }

    // public void LoadLevelButSaveHealth(int savedlevelIndex)
    // {
    //     SceneManager.LoadScene(savedlevelIndex);
    // }

    public void ContinueGame()
    {
        int savedHealth = PlayerPrefs.GetInt("PlayerHealth", healthBar.maxHealth); // Kaydedilen can miktarını al
        healthBar.SetHealth(savedHealth); // Kaydedilen can miktarı ile canı yeniden ayarla
        // healthBar.SetMaxHealth(healthBar.maxHealth);
        SceneManager.LoadScene(unlockedLevels); // Kaydedilen seviyeden devam et
    }

    // public void LastLevel()
    // {
    //     SceneManager.LoadScene(unlockedLevels);
    //     // SceneManager.LoadScene(1);
        
    // }

    public void ResetProgress()
    {
        unlockedLevels = 1;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        PlayerPrefs.SetInt("unlockedLevels", unlockedLevels);
        healthBar.ResetHealthForNewLevel();
        // scoreManager.ResetScore();
        PlayerPrefs.Save();
        // SceneManager.LoadScene(1);
    }

    
}
