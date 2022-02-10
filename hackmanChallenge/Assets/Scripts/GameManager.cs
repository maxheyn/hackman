using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public static class GameManager
{
    public static string currentWord = "";
    public static string CensorWord(string word)
    {
        string censoredWord = "";
        for (int i = 0; i < word.Length - 1; i++)
        {
            censoredWord += "_ ";
        }
        censoredWord += "_";

        return censoredWord;
    }

    public static string RevealLetter(string censoredWord, string guessWord, char letter)
    {
        StringBuilder sb = new StringBuilder(censoredWord);

        for (int i = 0; i < guessWord.Length; i++)
        {
            if (guessWord[i] == letter)
            {
                sb[i * 2] = letter;
            }
        }

        return sb.ToString();
    }

    public static void GameOver()
    {
        // ends the game
    }

    public static void Solved()
    {
        // word has been solved
    }
}