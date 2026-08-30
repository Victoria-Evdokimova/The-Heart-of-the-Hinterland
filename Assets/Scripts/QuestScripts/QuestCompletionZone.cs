using UnityEngine;

public class QuestCompletionZone : MonoBehaviour
{
    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private int questId;

    private bool used;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (used)
            return;

        if (!collision.CompareTag("Player"))
            return;

        if (questSystem.CurrentQuestId != questId)
            return;

        if (questSystem.CurrentState != QuestState.InProgress)
            return;

        used = true;

        questSystem.TurnInQuest();
    }
}