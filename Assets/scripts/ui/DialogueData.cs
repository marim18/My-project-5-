using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;

    [TextArea(2, 5)]
    public string text;
}

[System.Serializable]
public class DialogueData
{
    public DialogueLine[] lines;
}