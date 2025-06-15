using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Line")]
public class DialogueLine : ScriptableObject
{
    [TextArea] public string dialogueText;
    public Sprite characterPortrait;
    public string characterName;
    public DialogueChoice[] choices;
}
