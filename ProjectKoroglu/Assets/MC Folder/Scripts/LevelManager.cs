using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hoşgeldiniz");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ErMeydanina()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        //Options...
        Debug.Log("Seçenekler ekranı açılacak");
    }

    public void QuitGame()
    {
        Debug.Log("Çıkış Yaptınız.");
        Application.Quit();
    }

}
