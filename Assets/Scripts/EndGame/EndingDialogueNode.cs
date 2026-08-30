using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Node")]
public class EndingDialogueNode : ScriptableObject
{
    [TextArea]
    public string npcTextRU;
    [TextArea]
    public string npcTextEN;

    public EndingDialogueChoice[] choices;
}