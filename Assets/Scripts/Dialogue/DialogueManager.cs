using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public DialogueLine startingDialogue;  // Drag your first SO here
    public Image portraitImage;            // You can use RawImage too if preferred
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextButton;

    private DialogueLine currentLine;

    private void Start()
    {
        if (startingDialogue != null)
        {
            StartDialogue(startingDialogue);
        }

        nextButton.onClick.AddListener(HandleNext);
    }

    public void StartDialogue(DialogueLine dialogue)
    {
        currentLine = dialogue;

        nameText.text = dialogue.characterName;
        dialogueText.text = dialogue.dialogueText;

        if (portraitImage != null && dialogue.characterPortrait != null)
        {
            portraitImage.sprite = dialogue.characterPortrait;
        }
    }

    private void HandleNext()
    {
        if (currentLine == null) return;

        float roll = Random.value;
        bool isSuccess = roll <= currentLine.successProbability;

        if (isSuccess)
        {
            if (!string.IsNullOrEmpty(currentLine.successSceneName))
            {
                SceneManager.LoadScene(currentLine.successSceneName);
                return;
            }
            else if (currentLine.successNextLine != null)
            {
                StartDialogue(currentLine.successNextLine);
                return;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(currentLine.failSceneName))
            {
                SceneManager.LoadScene(currentLine.failSceneName);
                return;
            }
            else if (currentLine.failNextLine != null)
            {
                StartDialogue(currentLine.failNextLine);
                return;
            }
        }

        // If no outcome, just disable button or do nothing
        nextButton.interactable = false;
        dialogueText.text += "\n\n[End of Dialogue]";
    }
}
