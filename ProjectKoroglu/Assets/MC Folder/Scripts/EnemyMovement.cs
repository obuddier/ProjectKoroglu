using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public float stoppingDistance = 2f; 
    public float closeDistanceX = 10f; 
    private Transform target; 
    private bool isFollowing = false; 
    // public int health = 100; 

    // public int scoreValue = 20; 
    private ScoreManager scoreManager; 

    public GameObject projectilePrefab; 
    public Transform projectileSpawnPoint; 

    public float projectileInterval = 3f; 
    private bool canLaunchProjectile = true;

    public float projectileSpeed = 5f;
    public Animator enemyAnimator;

    // private float delayTimeOfSword = 2f; 
    // int collisionCount = 0;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun referansı

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

            if (distanceX < closeDistanceX && distanceY < 1)
            {
                isFollowing = true;
                enemyAnimator.SetBool("isWalking", true);
            }
            else if (isFollowing)
            {
                isFollowing = false;
                enemyAnimator.SetBool("isWalking", false);
            }

             if (isFollowing)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                if (canLaunchProjectile)
                {
                    LaunchProjectile();
                    canLaunchProjectile = false;
                    Invoke("ResetLaunchState", projectileInterval);
                }
            }

            if (target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
        }
    }

    void LaunchProjectile()
    {
        if (projectilePrefab != null && projectileSpawnPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            if (projectileRb != null)
            {
                projectileRb.velocity = new Vector2(transform.localScale.x * projectileSpeed, 0f);
            }

        }
    }

    void ResetLaunchState()
    {
        canLaunchProjectile = true;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // collisionCount++; // Temas sayacını artır

        // if (collisionCount == 1) // İlk temas
        // {
        //     return; // Hiçbir şey yapma, sadece çık
        // }

        // if (collisionCount == 2 && Time.time >= delayTimeOfSword) // İkinci temas ve 3 saniye geçtiyse
        // {
            if (collision.gameObject.CompareTag("EnemySword"))
            {
                Destroy(collision.gameObject);
                Debug.Log(collision.gameObject.tag + " destroyed on second collision.");
            }
        // }
    }
}
