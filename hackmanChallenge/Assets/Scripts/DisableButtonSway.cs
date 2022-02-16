using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButtonSway : MonoBehaviour
{
    public GameObject swayButtons;
    public GameObject stillButtons;


    // Currently not implemented
    public void SwayButtons(bool sway)
    {
        if (sway)
        {
            swayButtons.SetActive(true);
            stillButtons.SetActive(false);
        }
        else
        {
            swayButtons.SetActive(false);
            stillButtons.SetActive(true);
        }
    }
}
