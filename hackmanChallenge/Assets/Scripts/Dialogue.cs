using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // Simple wrapper for the dialogue, including a name and the text to be displayed.
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
