using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    public int referanceHealth;
    

    public int maxHealth = 100; // Varsayılan maksimum can değeri

    private void Start()
    {
        // Eğer PlayerPref'te kayıtlı bir can değeri varsa, onu kullan
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            int savedHealth = PlayerPrefs.GetInt("PlayerHealth");
            SetHealth(savedHealth);
        }
        else
        {
            // SetMaxHealth(maxHealth); // Eğer yoksa varsayılan maksimum canı kullan
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

        // Can değerini PlayerPref'e kaydet
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        // Can değerini PlayerPref'e kaydet
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
        // Debug.Log(health);
        referanceHealth = health;
    }

    public void ResetHealthForNewLevel()
    {
        SetHealth(maxHealth); // Yeni seviyeye geçildiğinde canı tam olarak doldur
    }
}
