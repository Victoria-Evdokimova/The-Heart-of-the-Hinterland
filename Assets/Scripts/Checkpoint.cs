using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        SaveManager.SaveCheckpoint(checkpointId);
    }
}