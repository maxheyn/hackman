using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static int maxLives = 6;
    public static int currentLives = maxLives;

    public void TakeDamage()   // called from LetterButton
    {
        if (currentLives == 0)
        {
            // game over
            //GameManager.GameOver();
            Debug.Log("Game Over");
        }
        else
        {
            Debug.Log("Took damage");
            Debug.Log("Current lives: " + currentLives);
            currentLives--;
            sprites[currentLives].SetActive(false);
        }
    }

    public void Reset()
    {
        currentLives = maxLives;
        for (int i = 0; i < maxLives; i++)
        {
            sprites[i].SetActive(true);
        }
    }
}