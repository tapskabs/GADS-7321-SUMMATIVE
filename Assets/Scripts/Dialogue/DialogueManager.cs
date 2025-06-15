using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Inspector References")]
    public DialogueSequence startingSequence;
    public Image portraitImage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextButton;

    private DialogueSequence currentSequence;
    private int entryIndex;

    void Start()
    {
        if (startingSequence != null)
        {
            StartSequence(startingSequence);
        }

        nextButton.onClick.AddListener(HandleNext);
    }

    void StartSequence(DialogueSequence sequence)
    {
        currentSequence = sequence;
        entryIndex = 0;
        DisplayCurrentEntry();
    }

    void DisplayCurrentEntry()
    {
        if (entryIndex < currentSequence.dialogueEntries.Length)
        {
            var entry = currentSequence.dialogueEntries[entryIndex];
            nameText.text = entry.characterName;
            dialogueText.text = entry.dialogueText;

            if (portraitImage != null && entry.characterPortrait != null)
            {
                portraitImage.sprite = entry.characterPortrait;
            }
        }
    }

    void HandleNext()
    {
        if (entryIndex < currentSequence.dialogueEntries.Length - 1)
        {
            entryIndex++;
            DisplayCurrentEntry();
        }
        else
        {
            // Dialogue finished, now handle probabilistic branching
            float roll = Random.value;
            bool success = roll <= currentSequence.successProbability;

            if (success)
            {
                if (!string.IsNullOrEmpty(currentSequence.successSceneName))
                {
                    SceneManager.LoadScene(currentSequence.successSceneName);
                    return;
                }
                else if (currentSequence.successSequence != null)
                {
                    StartSequence(currentSequence.successSequence);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(currentSequence.failSceneName))
                {
                    SceneManager.LoadScene(currentSequence.failSceneName);
                    return;
                }
                else if (currentSequence.failSequence != null)
                {
                    StartSequence(currentSequence.failSequence);
                    return;
                }
            }

            // If no outcome defined
            dialogueText.text += "\n\n[End of Dialogue]";
            nextButton.interactable = false;
        }
    }
}
