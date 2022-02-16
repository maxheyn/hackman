using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue gameOverDialogue;
    public Dialogue victoryDialogue;

    void Start()
    {
        // Starts the dialogue upon entering the scene.
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void GameOverDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(gameOverDialogue);
    }

    public void VictoryDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(victoryDialogue);
    }

}
