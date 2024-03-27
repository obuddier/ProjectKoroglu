using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public int scoreValue = 20;
    private ScoreManager scoreManager;
    public int maxHealth = 100;
    int currentHealth;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Color defaultColor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        defaultColor = GetComponent<SpriteRenderer>().color;
    }

    void Start()
    {
        currentHealth = maxHealth;
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        scoreManager.AddScore(scoreValue);
        animator.SetBool("isDead", true);
        Destroy(gameObject,2f);

    }

    public IEnumerator FlashRed()
    {
        sprite.color = new Color(1f, 0f, 0f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = defaultColor;
    }

}
