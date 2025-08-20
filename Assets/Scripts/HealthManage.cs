using UnityEngine;

public class HealthManage : MonoBehaviour
{

    [SerializeField] int health = 50;
    [SerializeField] bool isPlayer;
    [SerializeField] int score = 0;
    [SerializeField] ParticleSystem hitEffectExplosion;

    [SerializeField] bool doCameraShakeEffect;



    void OnTriggerEnter2D(Collider2D other)
    {
        // other is whatever except self
        //Debug.Log($"{gameObject.name} hit by {other.name}");
        DamageDealing dealer = other.GetComponent<DamageDealing>();
        if (dealer != null)
        {
            TakeDamage(dealer.GetDamage());
            dealer.Kill();
            PlayHitEffectExplosion();
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

    public int GetHealthPoints()
    {
        return health;
    }

    void PlayHitEffectExplosion()
    {
        if (hitEffectExplosion != null)
        {
            ParticleSystem instance = Instantiate(
                hitEffectExplosion, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

}
