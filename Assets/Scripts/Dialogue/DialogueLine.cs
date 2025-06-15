using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Line")]
public class DialogueLine : ScriptableObject
{
    public string characterName;
    [TextArea] public string dialogueText;
    public Sprite characterPortrait;

    [Range(0f, 1f)] public float successProbability = 1f;

    public DialogueLine successNextLine;
    public DialogueLine failNextLine;

    public string successSceneName;
    public string failSceneName;
}
