using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Skorun görüntülendiği UI elemanı
    // private int score = 0; // Oyuncunun skoru
    public LevelLockManager levelLockManager;

    public int[] levelScores; // Her seviye için ayrı skor tutulacak dizi
    public int currentLevel = 0; // Bulunduğunuz seviye
    
    // public GameObject GameOverPanel;
    // public GameObject Levels_Panel;

    public void Start()
    {
        // // Levels_Panel.SetActive(false);
        // // GameOverPanel.SetActive(false);
        // // Başlangıçta kaydedilen skoru yükle (eğer varsa)
        // if (PlayerPrefs.HasKey("SavedScore"))
        // {
        //     score = PlayerPrefs.GetInt("SavedScore");
        //     UpdateScoreText(); // Skoru güncelle
        // }

        int levelCount = SceneManager.sceneCountInBuildSettings - 1; // Menü sahnesini hariç tut
        levelScores = new int[levelCount];

        for (int i = 0; i < levelCount; i++)
        {
            levelScores[i] = PlayerPrefs.GetInt("Level" + (i + 1) + "Score", 0);
        }

        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel != 0)
        {
            UpdateScoreText();
            // Debug.Log("Bulunduğunuz seviye: " + currentLevel);
        }
    }

    public void AddScore(int points)
    {
        // score += points; // Skoru artır
        // UpdateScoreText(); // Skoru güncelle

        // // Skoru kaydet
        // PlayerPrefs.SetInt("SavedScore", score);
        // PlayerPrefs.Save(); // Değişiklikleri kaydet

        if (currentLevel - 1 < levelScores.Length)
        {
            levelScores[currentLevel - 1] += points;
            PlayerPrefs.SetInt("Level" + currentLevel + "Score", levelScores[currentLevel - 1]);
            PlayerPrefs.Save();

            UpdateScoreText();
        }
        else
        {
            Debug.LogWarning("Geçersiz seviye indeksi!");
        }
    }

    public void ResetScore()
    {
        // score = 0; // Skoru sıfırla
        // PlayerPrefs.SetInt("SavedScore", score); // Skoru sıfırla
        // PlayerPrefs.Save(); // Değişiklikleri kaydet
        // UpdateScoreText(); // Skoru güncelle
        // levelLockManager.ResetProgress();
        // SceneManager.LoadScene(1);


        int levelCount = SceneManager.sceneCountInBuildSettings;
        // for (int i = 0; i < levelCount; i++)
        // {
        //     PlayerPrefs.SetInt("Level" + (i + 1) + "Score", 0);
        //     levelScores[i] = 0;
        // }
        PlayerPrefs.SetInt("Level" + (0) + "Score", 0);
        PlayerPrefs.SetInt("Level" + (1) + "Score", 0);
        PlayerPrefs.SetInt("Level" + (2) + "Score", 0);
        PlayerPrefs.SetInt("Level" + (3) + "Score", 0);
        PlayerPrefs.SetInt("Level" + (4) + "Score", 0);

        PlayerPrefs.Save();
        UpdateScoreText();
        levelLockManager.ResetProgress();
        SceneManager.LoadScene(1);
        
    }

    public void UpdateScoreText()
    {
        if (scoreText != null && currentLevel - 1 < levelScores.Length && currentLevel > 0)
        {
            scoreText.text = "Skor: " + levelScores[currentLevel - 1] + " XP";
        }
        else if(currentLevel == 0)
        {
            return;
        }
    }

    public int UpdateScoreTextFrom()
    {
        return levelScores[currentLevel-1];
    }

    public int CalculateTotalScore()
    {
        int totalScore = 0;
        for (int i = 0; i < levelScores.Length; i++)
        {
            totalScore += levelScores[i];
        }
        return totalScore;
    }
}
