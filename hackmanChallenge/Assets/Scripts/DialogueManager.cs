using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


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

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Debug.Log("Ending Dialogue");
            EndDialogue();
            NewWord();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

    /**
    * @brief Disables the button and starts the coroutine to get a new word from the API
    */
    public void NewWord()
    {
        StartCoroutine(getRequest(APIHelper.API_URL + APIHelper.Base64Decode(APIHelper.API_KEY)));
    }

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
            Debug.Log("Received: " + JsonUtility.FromJson<Word>(uwr.downloadHandler.text).word);
            Word apiWord = JsonUtility.FromJson<Word>(uwr.downloadHandler.text);
            textGUI.text = GameManager.CensorWord(apiWord.word);
            GameManager.currentWord = apiWord.word;
        }
    }
}
