using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    public LetterButtonData btnData;
    public LivesData livesData;

    public void GuessLetter()
    {
        Debug.Log("GuessLetter: " + btnData.letter + "| Current word: " + GameManager.currentWord + "| guessField: " + btnData.guessField.text);
        // successful guess
        if (GameManager.currentWord.Contains(btnData.letter.ToString()))
        {
            btnData.guessField.text = GameManager.RevealLetter(btnData.guessField.text, GameManager.currentWord, btnData.letter);
            Debug.Log("Successful guess!");
        }
        else // failed guess
        {
            livesData.TakeDamage();
        }

        // Debug.Log("Pressed: " + data.letter);
    }
}
