using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage()
    {
        return damage;
    }
    public void Kill()  //upon hit
    {
        Destroy(gameObject);
    }


}
