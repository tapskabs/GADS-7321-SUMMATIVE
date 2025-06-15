using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Sequence")]
public class DialogueSequence : ScriptableObject
{
    public DialogueEntry[] dialogueEntries;

    [Header("Probabilistic Choice")]
    [Range(0f, 1f)] public float successProbability = 1f;
    public DialogueSequence successSequence;
    public DialogueSequence failSequence;
    public string successSceneName;
    public string failSceneName;
}

[System.Serializable]
public class DialogueEntry
{
    public string characterName;
    public Sprite characterPortrait;
    [TextArea] public string dialogueText;
}
