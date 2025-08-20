using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something just hit man");
    }
}
