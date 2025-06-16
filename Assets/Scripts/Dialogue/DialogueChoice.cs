using UnityEngine;
[System.Serializable]
public class DialogueChoice
{
    /*
    public string choiceText;
    public float successProbability; // e.g., 0.7 for 70% chance
    public DialogueLine successOutcome;
    public DialogueLine failOutcome;
    public string successSceneName;
    public string failSceneName; */

    public string choiceText;
    [Range(0f, 1f)] public float successProbability;

    public DialogueSequence successSequence;
    public DialogueSequence failSequence;

    public string successSceneName;
    public string failSceneName;
}
