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

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        animator.SetBool("isDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
        scoreManager.AddScore(scoreValue);
    }

}
