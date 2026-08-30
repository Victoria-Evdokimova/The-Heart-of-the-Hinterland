public class DialogueLine
{
    public SpeakerType Speaker;
    public string Name;
    public string Text;

    public DialogueLine
    (
        SpeakerType speaker,
        string name,
        string text
    )
    {
        Speaker = speaker;
        Name = name;
        Text = text;
    }
}