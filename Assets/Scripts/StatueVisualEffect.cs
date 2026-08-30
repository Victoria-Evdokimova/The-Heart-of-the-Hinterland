using UnityEngine;
using UnityEngine.Events;

public class StatueVisualEffect : MonoBehaviour
{
    public UnityEvent onStatueActivated;

    public bool IsPlayerNearby { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerNearby = false;
        }
    }

    public void Activate()
    {
        onStatueActivated?.Invoke();
    }
}