using UnityEngine;

public class HealthManage : MonoBehaviour
{

    [SerializeField] int health = 50;


    void OnTriggerEnter2D(Collider2D other)
    {
        // other is whatever except self
        //Debug.Log($"{gameObject.name} hit by {other.name}");
        DamageDealing dealer = other.GetComponent<DamageDealing>();
        if (dealer != null)
        {
            TakeDamage(dealer.GetDamage());
            dealer.Kill();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log($"New Health after damage is {health}");
    }
}
