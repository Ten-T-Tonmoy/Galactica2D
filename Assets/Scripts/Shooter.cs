using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 2f;
    //for firing randomness
    [SerializeField] float baseFiringRate = 0.2f;
    [SerializeField] float firingRateVariance = 0.1f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [SerializeField] public bool useAutomateShooting;

    // hiding or auto show in serialized?
    [HideInInspector] public bool isFiring; //hide?

    Coroutine firingCoroutine;

    void Awake()
    {

    }
    void Start()
    {
        if (useAutomateShooting)
        {
            isFiring = true;
        }

    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            //takes IEumerator method as argument
            firingCoroutine = StartCoroutine(FireContiniously());
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
                //Debug.Log($"Velocity set: {bulletRb.linearVelocity}");
            }

            Destroy(bulletInstance, projectileLifeTime);

            float timeGapForNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);

            timeGapForNextProjectile = Mathf.Clamp(timeGapForNextProjectile,
                minimumFiringRate, float.MaxValue);
            //basically sayin dont clamp upperbound at all!


            yield return new WaitForSeconds(timeGapForNextProjectile);
        }
    }
}
