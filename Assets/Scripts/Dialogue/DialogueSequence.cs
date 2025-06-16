using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Sequence")]
public class DialogueSequence : ScriptableObject
{
    public DialogueEntry[] dialogueEntries;

    public bool showChoicePanelAtEnd;
    public ChoicePanelData choicePanel;
}

[System.Serializable]
public class DialogueEntry
{
    public string characterName;
    public Sprite characterPortrait;
    [TextArea] public string dialogueText;
}

[System.Serializable]
public class ChoicePanelData
{
    [TextArea] public string eventDescription;
    public DialogueChoice choiceA;
    public DialogueChoice choiceB;
}


