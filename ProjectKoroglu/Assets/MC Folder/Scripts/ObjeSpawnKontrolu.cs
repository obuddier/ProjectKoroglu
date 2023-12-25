using UnityEngine;

public class ObjeSpawnKontrolu : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPrefab; // Prefabı alacak değişken

    [SerializeField]
    private Transform[] spawnPoints; // Obje'nin spawn edileceği yerlerin dizisi

    
    public float spawnInterval = 5f; // Yeniden spawn etme aralığı

    private float spawnTimer = 0f; // Spawn timer'ı

    void Update()
    {
        // Her karede spawnTimer'ı arttırır
        spawnTimer += Time.deltaTime;

        // Belirlenen süre kadar zaman geçtiğinde prefab'ı spawn et
        if (spawnTimer >= spawnInterval)
        {
            SpawnPrefab();
            spawnTimer = 0f; // Timer'ı sıfırla
        }
    }

    // Prefab'ı spawn eden fonksiyon
    void SpawnPrefab()
    {
        // Eğer spawnPrefab ve spawnPoints null değilse ve spawnPoints en az bir elemana sahipse
        if (spawnPrefab != null && spawnPoints != null && spawnPoints.Length > 0)
        {
            // Rastgele bir index seç
            int randomIndex = Random.Range(0, spawnPoints.Length);

            // Seçilen index'teki spawnPoint'i al
            Transform selectedSpawnPoint = spawnPoints[randomIndex];

            // Prefab'ı seçilen spawnPoint pozisyonunda ve rotasyonunda instantiate et
            Instantiate(spawnPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation, selectedSpawnPoint);
        }
        // else
        // {
        //     Debug.LogWarning("Prefab belirtilmemiş veya spawnPoints dizisi boş!");
        // }
    }
}
