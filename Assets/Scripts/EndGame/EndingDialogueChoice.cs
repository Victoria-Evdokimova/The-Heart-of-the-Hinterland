using System;
using UnityEngine;

[Serializable]
public class EndingDialogueChoice
{
    [TextArea]
    public string playerTextRU;
    [TextArea]
    public string playerTextEN;

    public bool isPositive;

    public EndingDialogueNode nextNode;
}