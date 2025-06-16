using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    public DialogueSequence startingSequence;
    public Image portraitImage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Button nextButton;

    [Header("Choice Panel UI")]
    public GameObject choicePanel;
    public TMP_Text eventDescriptionText;
    public Button choiceAButton;
    public TMP_Text choiceAText;
    public Button choiceBButton;
    public TMP_Text choiceBText;

    private DialogueSequence currentSequence;
    private int entryIndex;

    private void Start()
    {
        if (startingSequence != null)
            StartSequence(startingSequence);

        nextButton.onClick.AddListener(HandleNext);
    }

    public void StartSequence(DialogueSequence sequence)
    {
        currentSequence = sequence;
        entryIndex = 0;
        choicePanel.SetActive(false);
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
                portraitImage.sprite = entry.characterPortrait;
        }
    }

    void HandleNext()
    {
        if (entryIndex < currentSequence.dialogueEntries.Length - 1)
        {
            entryIndex++;
            DisplayCurrentEntry();
        }
        else if (currentSequence.showChoicePanelAtEnd && currentSequence.choicePanel != null)
        {
            ShowChoicePanel(currentSequence.choicePanel);
        }
        else
        {
            // No choice panel, end here
            dialogueText.text += "\n\n[End of Dialogue]";
            nextButton.interactable = false;
        }
    }

    void ShowChoicePanel(ChoicePanelData panelData)
    {
        nextButton.interactable = false;
        choicePanel.SetActive(true);

        eventDescriptionText.text = panelData.eventDescription;

        choiceAText.text = panelData.choiceA.choiceText;
        choiceAButton.onClick.RemoveAllListeners();
        choiceAButton.onClick.AddListener(() => HandleChoice(panelData.choiceA));

        choiceBText.text = panelData.choiceB.choiceText;
        choiceBButton.onClick.RemoveAllListeners();
        choiceBButton.onClick.AddListener(() => HandleChoice(panelData.choiceB));
    }

    void HandleChoice(DialogueChoice choice)
    {
        choicePanel.SetActive(false);

        float roll = Random.value;
        bool success = roll <= choice.successProbability;

        if (success)
        {
            if (!string.IsNullOrEmpty(choice.successSceneName))
            {
                SceneManager.LoadScene(choice.successSceneName);
                return;
            }
            else if (choice.successSequence != null)
            {
                StartSequence(choice.successSequence);
                return;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(choice.failSceneName))
            {
                SceneManager.LoadScene(choice.failSceneName);
                return;
            }
            else if (choice.failSequence != null)
            {
                StartSequence(choice.failSequence);
                return;
            }
        }

        dialogueText.text = "No outcome defined. Dialogue ends here.";
    }
}
