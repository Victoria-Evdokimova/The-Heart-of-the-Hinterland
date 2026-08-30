using UnityEngine;

public class DamageController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthController health = other.GetComponent<HealthController>();

        if (health != null)
        {
            health.TakeDamage();
        }
    }
}
