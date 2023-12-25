using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player tag'ıyla çarpışma gerçekleşirse animasyonu başlat
            PlayAnimation();
        }
    }

    private void PlayAnimation()
    {
        // Animator'ı al
        Animator animator = GetComponent<Animator>();

        // Eğer Animator bulunduysa
        if (animator != null)
        {
            // "IsTriggered" adında bir trigger'ı çalıştır
            animator.SetTrigger("IsTriggered");
        }
        else
        {
            Debug.LogError("Animator component not found!");
        }
    }
}
