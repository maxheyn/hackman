using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    public LetterButtonData btnData;
    public LivesData livesData;

    // Called when the user presses the buttons swimming in the water
    // Disables the button on press, and checks if the letter is in the word
    // Checks for victory on success and calls damage on incorrect guess
    public void GuessLetter()
    {
        gameObject.GetComponent<Button>().interactable = false;

        if (GameManager.currentWord.Contains(btnData.letter.ToString()))
        {
            // successful guess
            btnData.guessField.text = GameManager.RevealLetter(btnData.guessField.text, GameManager.currentWord, btnData.letter);
            PlaySound(true);

            //check for win
            if (!btnData.guessField.text.Contains("_"))
            {
                livesData.Victory();
            }
        }
        else
        {
            // failed guess
            livesData.TakeDamage();
            PlaySound(false);
        }
    }

    // Wild Card guess for pelican, generates a random letter from the word (chosen or not, does not necesarilly pick unchosen letters)
    // and then acts as a normal button guess. Does not give damage.
    // TODO: make this only pick unpicked letters
    // TODO: make this disable the respective letter button that was randomly picked
    public void WildCard()
    {
        char letter = GameManager.currentWord[Random.Range(0, GameManager.currentWord.Length)];

        gameObject.GetComponent<Button>().interactable = false;
        btnData.guessField.text = GameManager.RevealLetter(btnData.guessField.text, GameManager.currentWord, letter);
        PlaySound(true);

        if (!btnData.guessField.text.Contains("_"))
        {
            livesData.Victory();
        }
    }

    // Plays sound effects. If successful, plays "correct" sound, otherwise plays "incorrect" sound.
    private void PlaySound(bool correct)
    {
        if (correct)
            btnData.correctSounds[Random.Range(0, btnData.correctSounds.Length)].Play();
        else
            btnData.wrongSounds[Random.Range(0, btnData.wrongSounds.Length)].Play();
    }
}
