using UnityEngine;
using TMPro;

// Attached to each letter button.
// Holds the information that the button needs to
// convey to LetterButton when pressed
[System.Serializable]
public class LetterButtonData
{
    public char letter;
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public TextMeshProUGUI guessField;

    public AudioSource[] correctSounds;
    public AudioSource[] wrongSounds;
}
