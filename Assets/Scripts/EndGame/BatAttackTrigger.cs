using UnityEngine;

public class BatAttackTrigger : MonoBehaviour
{
    private BatEndingAttack bat;

    private void Awake()
    {
        bat = GetComponentInParent<BatEndingAttack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        bat.AttackPlayer();
    }
}