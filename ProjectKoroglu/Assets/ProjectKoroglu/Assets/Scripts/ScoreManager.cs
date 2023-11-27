using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Skorun görüntülendiği UI elemanı
    private int score = 0; // Oyuncunun skoru

    void Start()
    {
        // Başlangıçta kaydedilen skoru yükle (eğer varsa)
        if (PlayerPrefs.HasKey("SavedScore"))
        {
            score = PlayerPrefs.GetInt("SavedScore");
            UpdateScoreText(); // Skoru güncelle
        }
    }

    public void AddScore(int points)
    {
        score += points; // Skoru artır
        UpdateScoreText(); // Skoru güncelle

        // Skoru kaydet
        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.Save(); // Değişiklikleri kaydet
    }

    public void ResetScore()
    {
        score = 0; // Skoru sıfırla
        PlayerPrefs.SetInt("SavedScore", score); // Skoru sıfırla
        PlayerPrefs.Save(); // Değişiklikleri kaydet
        UpdateScoreText(); // Skoru güncelle
        SceneManager.LoadScene(1);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString() + " XP"; // Skor metnini güncelle
        }
    }
}
