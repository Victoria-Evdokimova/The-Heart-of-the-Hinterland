using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestController : MonoBehaviour
{
    [SerializeField]
    private DialogueUI dialogueUI;

    [SerializeField]
    private QuestSystem questSystem;

    private QuestGiver currentQuestGiver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(
            out QuestGiver giver))
        {
            return;
        }

        currentQuestGiver = giver;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent(
            out QuestGiver giver))
        {
            return;
        }

        if (currentQuestGiver == giver)
        {
            currentQuestGiver = null;
        }
    }

    private void StartDialogue()
    {
        if (currentQuestGiver == null)
            return;

        if (currentQuestGiver.questId !=
            questSystem.CurrentQuestId)
        {
            return;
        }

        FacePlayer(currentQuestGiver.transform);

        List<DialogueLine> dialogue =
            DialogueLoader.LoadDialogue(
                currentQuestGiver.npcFileName,
                questSystem.CurrentState
            );

        if (dialogue.Count == 0)
            return;

        dialogueUI.Show(
            dialogue,
            OnDialogueFinished
        );
    }

    private void FacePlayer(Transform npc)
    {
        Vector3 scale =
            npc.localScale;

        if (transform.position.x <
            npc.position.x)
        {
            scale.x = -1;
        }
        else
        {
            scale.x = 1;
        }

        npc.localScale = scale;
    }

    private void OnDialogueFinished()
    {
        switch (questSystem.CurrentState)
        {
            case QuestState.NotStarted:

                questSystem.StartQuest();

                break;

            case QuestState.ReadyToTurnIn:

                questSystem.TurnInQuest();

                break;
        }
    }
}