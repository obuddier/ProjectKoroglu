using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy; 
    public EnemyHealth enemyHealth;
    public ObjeSpawnKontrolu objeSpawnKontrolu;
    public Toggle easyToggle;
    public Toggle mediumToggle;
    public Toggle hardToggle;

    private const string difficultyKey = "Difficulty";

    void Start()
    {
        // Kayıtlı zorluk seviyesini kontrol et
        LoadDifficulty();
        
        // Toggle değerlerinin değişimlerini dinlemek için Listener'lar ekle
        easyToggle.onValueChanged.AddListener(delegate { OnEasyToggleValueChanged(); });
        mediumToggle.onValueChanged.AddListener(delegate { OnMediumToggleValueChanged(); });
        hardToggle.onValueChanged.AddListener(delegate { OnHardToggleValueChanged(); });
    }

    void OnEasyToggleValueChanged()
    {
        if (easyToggle.isOn)
        {
            mediumToggle.isOn = false;
            hardToggle.isOn = false;
            objeSpawnKontrolu.spawnInterval = 2f;
            enemyHealth.maxHealth = 50;
            enemyHealth.scoreValue = 30;
            SaveDifficulty(0); // 0 for easy difficulty
            Debug.Log("Seviye Easy 50-30");
        }
    }

    void OnMediumToggleValueChanged()
    {
        if (mediumToggle.isOn)
        {
            easyToggle.isOn = false;
            hardToggle.isOn = false;
            objeSpawnKontrolu.spawnInterval = 2f;
            enemyHealth.maxHealth = 100;
            enemyHealth.scoreValue = 70;
            SaveDifficulty(1); // 1 for medium difficulty
            Debug.Log("Seviye Orta 100-70");
        }
    }

    void OnHardToggleValueChanged()
    {
        if (hardToggle.isOn)
        {
            easyToggle.isOn = false;
            mediumToggle.isOn = false;
            objeSpawnKontrolu.spawnInterval = .5f;
            enemyHealth.maxHealth = 200;
            enemyHealth.scoreValue = 100;
            SaveDifficulty(2); // 2 for hard difficulty
            Debug.Log("Seviye Hard 200-100");
        }
    }

    // Kaydedilen zorluk seviyesini PlayerPrefs'e kaydet
    void SaveDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(difficultyKey, difficulty);
        PlayerPrefs.Save();
    }

    // Kaydedilmiş zorluk seviyesini yükle
    void LoadDifficulty()
    {
        int difficulty = PlayerPrefs.GetInt(difficultyKey, 0); // Varsayılan olarak easy
        switch (difficulty)
        {
            case 0:
                easyToggle.isOn = true;
                OnEasyToggleValueChanged();
                break;
            case 1:
                mediumToggle.isOn = true;
                OnMediumToggleValueChanged();
                break;
            case 2:
                hardToggle.isOn = true;
                OnHardToggleValueChanged();
                break;
            default:
                easyToggle.isOn = true;
                OnEasyToggleValueChanged();
                break;
        }
    }

    public int GetScoreValueByDifficulty()
    {
        int scoreValue = 0;

        if (easyToggle.isOn)
        {
            scoreValue = 30;
        }
        else if (mediumToggle.isOn)
        {
            scoreValue = 70;
        }
        else if (hardToggle.isOn)
        {
            scoreValue = 100;
        }

        return scoreValue;
    }
}
