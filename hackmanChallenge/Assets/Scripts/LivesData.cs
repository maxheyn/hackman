using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [System.Serializable]
// public static class LivesData
// {
//     public static Sprite[] sprites;
//     public static int maxLives = 6;
//     public static int currentLives;
// }

public class LivesData : MonoBehaviour
{
    public GameObject[] sprites;
    public Button[] buttons;
    public DialogueTrigger dt;

    public static int maxLives = 6;
    public static int currentLives = maxLives;

    public void TakeDamage()   // called from LetterButton
    {
        if (currentLives == 1)
        {
            // game over

            sprites[maxLives - 1].GetComponent<Animator>().SetBool("dead", true);
            GameOver();
        }
        else
        {
            // lose a life
            currentLives--;
            sprites[maxLives - currentLives - 1].GetComponent<Animator>().SetBool("dead", true);
        }
    }

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

    private void GameOver()
    {
        // Pop up Dialogue
        dt.GameOverDialogue();

        // Reset lives
        Reset();
    }

    public void Victory()
    {
        dt.VictoryDialogue();
        Reset();
    }




}
