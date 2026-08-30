using Unity.Cinemachine;
using UnityEngine;

public class EndingDialogueZone : MonoBehaviour
{
    [SerializeField] private EndingDialogueController dialogueController;
    private bool activated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;

        if (collision.CompareTag("Player"))
        {
            activated = true;
            dialogueController.StartDialogue();
        }
    }
}


