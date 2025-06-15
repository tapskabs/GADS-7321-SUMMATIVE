using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image portraitImage;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;

    private DialogueLine currentLine;

    public void StartDialogue(DialogueLine startingLine)
    {
        currentLine = startingLine;
        DisplayLine(currentLine);
    }

    void DisplayLine(DialogueLine line)
    {
        nameText.text = line.characterName;
        portraitImage.sprite = line.characterPortrait;
        dialogueText.text = line.dialogueText;

        foreach (Transform child in choicesContainer) Destroy(child.gameObject);

        foreach (var choice in line.choices)
        {
            var button = Instantiate(choiceButtonPrefab, choicesContainer);
            button.GetComponentInChildren<TMP_Text>().text = choice.choiceText;
            button.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choice));
        }
    }

    void OnChoiceSelected(DialogueChoice choice)
    {
        float roll = Random.value;
        bool success = roll <= choice.successProbability;

        if (success)
        {
            if (!string.IsNullOrEmpty(choice.successSceneName))
                SceneManager.LoadScene(choice.successSceneName);
            else if (choice.successOutcome != null)
                DisplayLine(choice.successOutcome);
        }
        else
        {
            if (!string.IsNullOrEmpty(choice.failSceneName))
                SceneManager.LoadScene(choice.failSceneName);
            else if (choice.failOutcome != null)
                DisplayLine(choice.failOutcome);
        }
    }
}
