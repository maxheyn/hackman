using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesData : MonoBehaviour
{
    public GameObject[] sprites;
    public Button[] buttons;
    public DialogueTrigger dt;
    public TextMeshProUGUI streakCounter;

    public static int maxLives = 6;
    public static int currentLives = maxLives;
    private int streak = 0;
    private int best = 0;

    // Makes the player take damage and plays the appropriate animation.
    // If the play is out of lives, the game is over.
    public void TakeDamage()
    {
        if (currentLives == 1)
        {
            // game over
            sprites[maxLives - 1].GetComponent<Animator>().SetBool("dead", true); //technically this doesn't show because of GameOveR() but it's here for the sake of completeness
            GameOver();
        }
        else
        {
            // lose a life
            currentLives--;
            sprites[maxLives - currentLives - 1].GetComponent<Animator>().SetBool("dead", true);
        }
    }

    // Resets the UI and data values to their default values.
    private void Reset()
    {
        currentLives = maxLives;
        for (int i = 0; i < maxLives; i++)
        {
            sprites[i].SetActive(true);
            sprites[i].GetComponent<Animator>().SetBool("dead", false);
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }

    // Called when the player does not have any lives left.
    // Displays the word they didn't guess in the upcoming dialogue.
    // Resets the streak counter.
    private void GameOver()
    {
        streak = 0;
        streakCounter.text = "Score: " + streak + " | Best: " + best;
        // Pop up Dialogue
        dt.gameOverDialogue.sentences[0] = "The word was " + "\"" + GameManager.currentWord + "\"";
        dt.GameOverDialogue();

        // Reset lives
        Reset();
    }

    // Called when the player successfully guesses the word.
    // Adds to the streak counter and checks if the player has beaten their best score.
    public void Victory()
    {
        streak++;
        if (streak > best)
        {
            best = streak;
        }
        streakCounter.text = "Score: " + streak + " | Best: " + best;
        dt.VictoryDialogue();
        Reset();
    }




}
