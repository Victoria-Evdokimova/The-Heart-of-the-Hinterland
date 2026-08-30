using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [Header("Player")]

    [SerializeField]
    private GameObject playerDialogueBackground;

    [SerializeField]
    private TMP_Text playerName;

    [SerializeField]
    private TMP_Text playerDialogue;

    [Header("Villager")]

    [SerializeField]
    private GameObject villagerDialogueBackground;

    [SerializeField]
    private TMP_Text villagerName;

    [SerializeField]
    private TMP_Text villagerDialogue;

    private List<DialogueLine> lines;

    private int currentIndex;

    private Action onDialogueFinished;

    public void Show
    (
        List<DialogueLine> dialogueLines,
        Action finishCallback
    )
    {
        lines = dialogueLines;

        currentIndex = 0;

        onDialogueFinished =
            finishCallback;

        gameObject.SetActive(true);

        DisplayCurrentLine();
    }

    public void Next()
    {
        currentIndex++;

        if (currentIndex >= lines.Count)
        {
            gameObject.SetActive(false);

            onDialogueFinished?.Invoke();

            return;
        }

        DisplayCurrentLine();
    }

    private void DisplayCurrentLine()
    {
        DialogueLine line =
            lines[currentIndex];

        if (line.Speaker ==
            SpeakerType.Villager)
        {
            villagerDialogueBackground.SetActive(true);
            playerDialogueBackground.SetActive(false);

            villagerName.text =
                line.Name;

            villagerDialogue.text =
                line.Text;
        }
        else
        {
            villagerDialogueBackground.SetActive(false);
            playerDialogueBackground.SetActive(true);

            playerName.text =
                line.Name;

            playerDialogue.text =
                line.Text;
        }
    }
}