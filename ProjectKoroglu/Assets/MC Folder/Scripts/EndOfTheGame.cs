using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfTheGame : MonoBehaviour
{
    public ScoreManager scoreManager; // ScoreManager betiğinizin referansı
    public TextMeshProUGUI TotalScore;

    void Start()
    {
        // scoreManager = GetComponent<ScoreManager>(); // ScoreManager betiğinizin referansını alın

        // Diğer kodlarınız...

        int totalScore = scoreManager.CalculateTotalScore(); // Tüm skorları topla
        TotalScore.text = "Total Skor : "+ totalScore;
        Debug.Log("Toplam Skor: " + totalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu(int a)
    {
        SceneManager.LoadScene(a);
    }
}
