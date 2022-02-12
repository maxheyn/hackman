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
        if (currentLives == 1)
        {
            // game over
            GameManager.GameOver();
            sprites[maxLives - 1].GetComponent<Animator>().SetBool("dead", true);
            Debug.Log("Game Over");
        }
        else
        {
            currentLives--;
            Debug.Log(maxLives - currentLives);
            sprites[maxLives - currentLives - 1].GetComponent<Animator>().SetBool("dead", true);
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