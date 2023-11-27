using UnityEngine;
using System.Collections;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hızı
    public float jumpForce = 8f; // Zıplama kuvveti
    public float dashForce = 10f; // Dash kuvveti
    public float dashDuration = 0.2f; // Dash süresi
    private bool isDashing = false; // Dash durumu kontrolü
    private bool amDead = false;

    public TextMeshProUGUI DeathMessage;

    private Rigidbody2D rb;
    private bool isGrounded = false; // Zeminde olma kontrolü

    private Animator animator;

    // [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    public HealthBar HealthBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            PlayerPrefs.SetString("LastCheckPoint", other.gameObject.name); // Son checkpoint'i kaydet
            // Debug.Log(other.gameObject.name);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();

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
            DeathMessage.gameObject.SetActive(true);
            DeathMessage.text = "Öldün Artık Haraket Edemezsin"; 
            Time.timeScale = 0f;
        }
        else if(amDead == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // "Fire1" tuşuna basıldığında AttackTrigger tetikleyicisini çalıştır
                if (animator != null)
                {
                    // Debug.Log("Player1 also took Damage");
                    // TakeDamage(20);
                    animator.SetTrigger("AttackTrigger");
                }
            }

        
            
            // Yatay (sağ-sol) hareket için giriş alma
            float moveInput = Input.GetAxis("Horizontal");
            Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
            rb.velocity = moveVelocity;

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

    // Zemin kontrolü
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("EnemySword"))
        {
            TakeDamage(20);
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

    void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Enemy")) {
        // Karakterin düşmanı itmesini engellemek için tepkiyi sıfıra eşitle
        collision.rigidbody.velocity = Vector3.zero;
        collision.rigidbody.angularVelocity = Vector3.zero;
    }
}

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
    void OnTriggerEnter(Collider other)
    {
        // if(other.gameObject.tag == "Sword")
        // {
        //     TakeDamage(20);
        //     Destroy(other.gameObject);
        // }

        
    }

}
