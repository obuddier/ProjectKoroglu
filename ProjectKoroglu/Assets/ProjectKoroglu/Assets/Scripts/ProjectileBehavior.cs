using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float projectileSpeed = 5f; // Fırlatılan nesnenin hızı

    void Update()
    {
        // Nesneyi x ekseni boyunca ilerletme
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);

        // Eğer nesne "Range" Tag'lı bir nesneye değerse, nesneyi yok et
        if (CheckCollisionWithTag("Range"))
        {
            Destroy(gameObject);
        }

        // Eğer nesne "Player" Tag'lı bir nesneye değerse, nesneyi yok et
        if (CheckCollisionWithTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Belirli bir Tag'e sahip bir nesne ile çarpışmayı kontrol etme fonksiyonu
    bool CheckCollisionWithTag(string tag)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }

        return false;
    }
}
