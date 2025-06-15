[System.Serializable]
public class DialogueChoice
{
    public string choiceText;
    public float successProbability; // e.g., 0.7 for 70% chance
    public DialogueLine successOutcome;
    public DialogueLine failOutcome;
    public string successSceneName;
    public string failSceneName;
}
