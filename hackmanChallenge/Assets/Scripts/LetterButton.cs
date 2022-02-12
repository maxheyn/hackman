using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    public LetterButtonData btnData;
    public LivesData livesData;

    public void GuessLetter()
    {
        gameObject.GetComponent<Button>().interactable = false;


        if (GameManager.currentWord.Contains(btnData.letter.ToString()))
        {
            // successful guess
            btnData.guessField.text = GameManager.RevealLetter(btnData.guessField.text, GameManager.currentWord, btnData.letter);
            PlaySound(true);
        }
        else
        {
            // failed guess
            livesData.TakeDamage();
            PlaySound(false);
        }

    }

    private void PlaySound(bool correct)
    {
        if (correct)
            btnData.correctSounds[Random.Range(0, btnData.correctSounds.Length)].Play();
        else
            btnData.wrongSounds[Random.Range(0, btnData.wrongSounds.Length)].Play();
    }
}
