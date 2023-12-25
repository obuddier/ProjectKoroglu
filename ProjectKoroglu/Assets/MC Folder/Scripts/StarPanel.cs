using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarPanel : MonoBehaviour
{
    ToggleController toggleController;
    ScoreManager scoreManager;
    public GameObject Three_Star;
    public GameObject Two_Star;
    public GameObject One_Star;
    int divide;

    public TextMeshProUGUI killCountText;
    void Start()
    {
       toggleController = FindObjectOfType<ToggleController>();
       scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void KillCount()
    {
        Debug.Log(scoreManager.UpdateScoreTextFrom());
        
        if(scoreManager.UpdateScoreTextFrom() <= 40f)
        {
            One_Star.SetActive(true);
            Two_Star.SetActive(false);
            Three_Star.SetActive(false);
        }
        else if (scoreManager.UpdateScoreTextFrom() > 40f && scoreManager.UpdateScoreTextFrom() <= 80f)
        {
            One_Star.SetActive(false);
            Two_Star.SetActive(true);
            Three_Star.SetActive(false);
        }
        else if(80f < scoreManager.UpdateScoreTextFrom())
        {
            One_Star.SetActive(false);
            Two_Star.SetActive(false);
            Three_Star.SetActive(true);
        }

        killCountText.text = "Alt Edilen Düþman :" + scoreManager.UpdateScoreTextFrom()/toggleController.GetScoreValueByDifficulty();
    }
}
