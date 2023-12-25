using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;


public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hızı
    public float jumpForce = 8f; // Zıplama kuvveti
    public float dashForce = 10f; // Dash kuvveti
    public float dashDuration = 0.2f; // Dash süresi
    private bool isDashing = false; // Dash durumu kontrolü
    public bool amDead = false;

    public TextMeshProUGUI DeathMessage;

    private Rigidbody2D rb;
    private bool isGrounded = false; // Zeminde olma kontrolü

    private Animator animator;

    // [SerializeField] int maxHealth = 100;
    public int currentHealth;
    public HealthBar HealthBar;
    public LoadLevel loadLevel;
    public PassLevel passLevel;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    void Start()
    {        
        currentHealth = HealthBar.referanceHealth;
        // Debug.Log(currentHealth);

        animator = GetComponent<Animator>();

        Time.timeScale = 1f;

        rb = GetComponent<Rigidbody2D>();

        DeathMessage.gameObject.SetActive(false);
        
        // Oyun başladığında son checkpoint'e git
        if (PlayerPrefs.HasKey("LastCheckPoint"))
        {
            GameObject lastCheckPoint = GameObject.Find(PlayerPrefs.GetString("LastCheckPoint"));
            if (lastCheckPoint != null)
            {
                transform.position = lastCheckPoint.transform.position;
            }
        }
    }


    void Update()
    {
        if (amDead == true)
        {
            animator.SetBool("isDead", true);//ölüm izlenecek -bhn
            // DeathMessage.gameObject.SetActive(true);
            loadLevel.GetBackToGameOverPanel();
            // DeathMessage.text = "Öldün Artık Hareket Edemezsin"; 
            Time.timeScale = 0f;
            amDead = false;

        }
        else if(amDead == false)
        {
            if(Time.time >= nextAttackTime)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    // "Fire1" tuşuna basıldığında AttackTrigger tetikleyicisini çalıştır
                    if (animator != null)
                    {
                        Attack(); 
                        // Debug.Log("Player1 also took Damage");
                        // TakeDamage(20);
                        // animator.SetTrigger("AttackTrigger");
                        
                    }
                }
            }
            // Yatay (sağ-sol) hareket için giriş alma
            float moveInput = Input.GetAxis("Horizontal");
            Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            rb.velocity = moveVelocity;

            if(Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("isWalking",true);
            }
            else
            {
                animator.SetBool("isWalking",false);
            }

            // Karakterin yönünü, hareket yönüne göre döndürme
            if (moveInput < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Karakteri sola döndürme
            }
            else if (moveInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Karakteri sağa döndürme
            }

            // Zıplama işlemi
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            // Dash işlemi
            if (Input.GetButtonDown("Fire2") && !isDashing)
            {
                StartCoroutine(Dash());
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            PlayerPrefs.SetString("LastCheckPoint", other.gameObject.name); // Son checkpoint'i kaydet
            // Debug.Log(other.gameObject.name);
        }

        if (other.CompareTag("FirstLevel"))
        {
            HealthBar.ResetHealthForNewLevel();
            currentHealth = 100;
            // SceneManager.LoadScene(2);
            loadLevel.Star_Panel_Open();
            passLevel.PassTheLevel();
            // Debug.Log(other.gameObject.name);
        }
        else if (other.CompareTag("SecondLevel"))
        {
            HealthBar.ResetHealthForNewLevel();
            currentHealth = 100;
            // SceneManager.LoadScene(3);
            loadLevel.Star_Panel_Open();
            passLevel.PassTheLevel();
            // Debug.Log(other.gameObject.name);
        }
        else if (other.CompareTag("ThirdLevel"))
        {
            HealthBar.ResetHealthForNewLevel();
            currentHealth = 100;
            // SceneManager.LoadScene(4);
            
            //Şimdilik oyun 3 level olduğu için son bölümden sonra direk end of game scene'e gidilecek.
            //En sonki levelde loadLevel.Star_Panel_Open(); olmamalı! Direk end of game scene'ne gitmeli.
            loadLevel.Star_Panel_Open();
            passLevel.PassTheLevel();
            // Debug.Log(other.gameObject.name);
        }
        else if (other.CompareTag("FourthLevel"))
        {
            HealthBar.ResetHealthForNewLevel();
            currentHealth = 100;
            // SceneManager.LoadScene(3); //  Leevel eklendikçe düzeltilecek
            loadLevel.Star_Panel_Open();
            passLevel.PassTheLevel(); 
            // Debug.Log(other.gameObject.name);
        }
    }

    void Attack()
    {
        animator.SetTrigger("AttackTrigger");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(50);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    

    // Zemin kontrolü
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("EnemySword"))
        {
            TakeDamage(10);
            animator.SetTrigger("HurtTrigger");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Can İksiri"))
        {
            TakeHealth(10);
            Destroy(other.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

//     void OnCollisionEnter(Collision collision) {
//     if (collision.gameObject.CompareTag("Enemy")) {
//         // Karakterin düşmanı itmesini engellemek için tepkiyi sıfıra eşitle
//         collision.rigidbody.velocity = Vector3.zero;
//         collision.rigidbody.angularVelocity = Vector3.zero;
//     }
// }

    // Dash fonksiyonu
    IEnumerator Dash()
    {
        isDashing = true;
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = new Vector2(transform.localScale.x * dashForce, rb.velocity.y);
            yield return null;
        }

        isDashing = false;
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Debug.Log(currentHealth);

        HealthBar.SetHealth(currentHealth);
        // Debug.Log("Player1 took Damage");

        if(currentHealth == 0)
        {
            amDead = true;
            // Debug.Log("Player1 is Died");
            // thetext.text = "Player2 is Won";
            // Panel.SetActive(true);
        }
        // else
        // {
        //     Panel.SetActive(false);
        // }
    }
    void TakeHealth(int damage)
    {
        currentHealth += damage;

        HealthBar.SetHealth(currentHealth);
    }

}
