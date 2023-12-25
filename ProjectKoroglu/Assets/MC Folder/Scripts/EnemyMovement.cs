using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Düşmanın hareket hızı
    public float stoppingDistance = 2f; // Düşmanın duracağı mesafe
    public float closeDistanceX = 10f; // Karaktere yakın mesafe (x ekseni)
    private Transform target; // Oyuncu hedefi
    private bool isFollowing = false; // Takip durumu kontrolü
    // public int health = 100; // Düşmanın sağlık değeri

    // public int scoreValue = 20; // Her düşmanın skor değeri
    private ScoreManager scoreManager; // Skor yöneticisi referans

    public GameObject projectilePrefab; // Fırlatılacak nesne
    public Transform projectileSpawnPoint; // Fırlatma noktası

    public float projectileInterval = 3f; // Fırlatma aralığı (saniye)
    private bool canLaunchProjectile = true;

    public float projectileSpeed = 5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun referansı

        // Skor yöneticisini bul
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }

    void Update()
    {
        if (target != null)
        {
            float distanceX = Mathf.Abs(target.position.x - transform.position.x);
            float distanceY = Mathf.Abs(target.position.y - transform.position.y);

            // Düşmanın X ekseni mesafesini kontrol etme, Y ekseni kontrolü kaldırıldı
            if (distanceX < closeDistanceX && distanceY < 1)
            {
                isFollowing = true;
            }
            else if (isFollowing)
            {
                // Takip durumunu kontrol etme
                isFollowing = false;
                // Fırlatma fonksiyonunu çağır
                // LaunchProjectile();
                // Debug.Log("fırlatılmalı following...");
            }

             if (isFollowing)
            {
                // Karaktere yakınsa hareket et
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                if (canLaunchProjectile)
                {
                    // Fırlatma fonksiyonunu çağır ve bir sonraki fırlatma için bekleme süresini belirle
                    LaunchProjectile();
                    canLaunchProjectile = false;
                    Invoke("ResetLaunchState", projectileInterval);
                }
            }

            // Düşmanın yönünü, hareket yönüne göre döndürme (opsiyonel)
            if (target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Düşmanı sola döndürme
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // Düşmanı sağa döndürme
            }
        }
    }

    void LaunchProjectile()
    {
        if (projectilePrefab != null && projectileSpawnPoint != null)
        {
            // Nesneyi fırlat
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            
            // Nesneye bir kuvvet uygula
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            if (projectileRb != null)
            {
                // Düşmanın yönüne doğru kuvvet uygula
                projectileRb.velocity = new Vector2(transform.localScale.x * projectileSpeed, 0f);
            }

            // Debug.Log("Al sana bıçak");
        }
    }

    void ResetLaunchState()
    {
        canLaunchProjectile = true;
    }


    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Sword"))
    //     {
    //         // "Sword" tag'ine sahip nesneyle çarpışma durumu
    //         health -= 50; // Canı 50 azalt
    //         if (health <= 0)
    //         {
    //             // Canı 0 veya daha azsa düşmanı yok et
    //             Destroy(gameObject);
    //             // Debug.Log("Hit Sword...");
    //             // scoreManager.AddScore(scoreValue);
    //         }
    //     }
    //     // else
    //     // {
    //     //     Debug.Log(collision.gameObject.tag);
    //     // }
    // }
}
