using System.Collections.Generic;
using UnityEngine;

public static class DialogueLoader
{
    public static List<DialogueLine> LoadDialogue
    (
        string npcName,
        QuestState state
    )
    {
        List<DialogueLine> result =
            new List<DialogueLine>();

        string language =
            SaveManager.LoadLanguage();

        TextAsset file =
            Resources.Load<TextAsset>
            (
                $"Dialogues/{language}/{npcName}"
            );

        if (file == null)
            return result;

        string section = state switch
        {
            QuestState.NotStarted => "[START]",
            QuestState.InProgress => "[REMINDER]",
            QuestState.ReadyToTurnIn => "[COMPLETE]",
            _ => ""
        };

        bool readingSection = false;

        string[] lines =
            file.text.Split('\n');

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();

            if (line == section)
            {
                readingSection = true;
                continue;
            }

            if (line.StartsWith("[") &&
                line.EndsWith("]") &&
                readingSection)
            {
                break;
            }

            if (!readingSection)
                continue;

            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts =
                line.Split('|');

            if (parts.Length != 3)
                continue;

            SpeakerType speaker =
                parts[0] == "V"
                ? SpeakerType.Villager
                : SpeakerType.Player;

            result.Add(
                new DialogueLine(
                    speaker,
                    parts[1],
                    parts[2]
                )
            );
        }

        return result;
    }
}