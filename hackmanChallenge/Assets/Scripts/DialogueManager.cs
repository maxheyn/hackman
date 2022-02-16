using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

// Everything to do with displaying the Dialogue and 
// interations it has with the rest of the game.
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textGUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Opens the dialogue box adds the sentences to the queue.
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Displays the next sentence in the queue.
    // Closes the dialogue box if the queue is empty.
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            NewWord();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Coroutine that displays the sentence one letter at a time.
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    // Closes the dialogue box.
    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

    // Calls the Coroutine for a new word from the API, with 
    public void NewWord(int length = -1)
    {
        if (length == -1)
            StartCoroutine(getRequest(APIHelper.API_URL + APIHelper.Base64Decode(APIHelper.API_KEY)));
        else
            StartCoroutine(getRequest(APIHelper.API_URL + APIHelper.Base64Decode(APIHelper.API_KEY) + "&length=" + length));
    }

    // Coroutine that fetches a new word from the API.
    // Stores the word in the GameManager.
    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Unity Web Request Error");
        }
        else
        {
            Word apiWord = JsonUtility.FromJson<Word>(uwr.downloadHandler.text);
            string finalWord = apiWord.word;

            // check if the API successfully returned a word, if not, use the default from api helper
            // this way the game won't break if the API is down or rate limited
            if (apiWord.word == null || apiWord.word == "")
            {
                finalWord = APIHelper.GetRandomWordIncaseTheClemsonHackmanAPIDoesNotWorkForSomeReason();
            }

            textGUI.text = GameManager.CensorWord(finalWord);
            GameManager.currentWord = finalWord;
        }
    }
}
