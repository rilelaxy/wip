using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image portraitImage;
    public Button nextButton;

    private Queue<DialogueLine> dialogueQueue;
    private bool isDialogueActive = false;
    private bool isDisplayingLine = false;
    private float textDisplaySpeed = 0.05f;

    void Start()
    {
        dialogueQueue = new Queue<DialogueLine>();
        nextButton.onClick.AddListener(DisplayNextLine);
        dialoguePanel.SetActive(false); // hide dialogue panel
    }

    public void StartDialogue(string name, DialogueLine[] dialogueLines)
    {
        if (isDialogueActive)
        {
            Debug.LogWarning("Dialogue is already active.");
            return;
        }

        dialogueQueue.Clear();
        foreach (DialogueLine line in dialogueLines)
        {
            dialogueQueue.Enqueue(line);
        }

        isDialogueActive = true;
        dialoguePanel.SetActive(true); //  dialogue panel
        nameText.text = name; // character name
        DisplayNextLine();
    }

    private void DisplayNextLine()
    {
        if (isDisplayingLine) return;

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = dialogueQueue.Dequeue();
        StartCoroutine(TypeLine(currentLine));
    }

    private IEnumerator TypeLine(DialogueLine line)
    {
        isDisplayingLine = true;
        dialogueText.text = ""; // Clear text before typing

        foreach (char letter in line.text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textDisplaySpeed);
        }

        isDisplayingLine = false;

        // Display portrait
        if (portraitImage != null)
        {
            portraitImage.sprite = line.portrait;
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialogueText.text = "";
        nameText.text = "";
        if (portraitImage != null)
        {
            portraitImage.sprite = null; // Clear portrait when dialogue ends
        }
        dialoguePanel.SetActive(false); // Hide dialogue panel
    }
}
