using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;


    public bool isFiring; //hide?

    Coroutine firingCoroutine;

    void Awake()
    {

    }
    void Start()
    {

    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine != null)
        {
            //takes IEumerator method as argument
            Coroutine firingCoroutine = StartCoroutine(FireContiniously());
        }
        else if (isFiring == false && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContiniously()
    {
        while (true)
        {
            GameObject bulletInstance = Instantiate(
                   projectilePrefab, transform.position, Quaternion.identity
                );
            //moving rigidbody moves the collider and sprite auto

            Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = transform.up * projectileSpeed;
            }
            float timeGapForNextProjectile = 0f;


            yield return new WaitForSeconds(timeGapForNextProjectile);
        }
    }
}
