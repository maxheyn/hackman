using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    public LetterButtonData data;
    public void GuessLetter(string s)
    {
        data.guessField.text = GameManager.revealLetter(data.guessField.text, GameManager.currentWord, data.letter);
        Debug.Log("Pressed: " + data.letter);
        //gameObject.GetComponent<SpriteRenderer>().sprite = data.pressedSprite;
    }
}
