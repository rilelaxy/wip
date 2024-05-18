using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string characterName; 
    public DialogueLine[] dialogueLines;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(characterName, dialogueLines); 
        }
    }
}
