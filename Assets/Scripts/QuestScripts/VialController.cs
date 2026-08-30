using UnityEngine;
using UnityEngine.InputSystem;

public class VialController : MonoBehaviour
{
    [SerializeField] private QuestSystem questSystem;
    [SerializeField] private StatueVisualEffect statue;

    private bool isUsed;

    private void Update()
    {
        if (isUsed)
            return;

        if (!gameObject.activeInHierarchy)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            UseVial();
        }
    }

    private void UseVial()
    {
        if (questSystem.CurrentQuestId != 1)
            return;

        if (questSystem.CurrentState != QuestState.InProgress)
            return;

        if (!statue.IsPlayerNearby)
            return;

        isUsed = true;

        statue.Activate();

        questSystem.CompleteQuestObjective();

        gameObject.SetActive(false);
    }
}