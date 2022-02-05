using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class TestInputScript : MonoBehaviour
{
    public TextMeshProUGUI textGUI;

    public void GetInput()
    {
        string letter = this.gameObject.GetComponent<TMP_InputField>().text;
        textGUI.text = GameManager.revealLetter(textGUI.text, GameManager.currentWord, letter[0]);
    }
}
