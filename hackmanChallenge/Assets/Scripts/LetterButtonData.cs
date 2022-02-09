using UnityEngine;
using TMPro;

[System.Serializable]
public class LetterButtonData
{
    public char letter;
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public TextMeshProUGUI guessField;
}
