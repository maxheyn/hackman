using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class TestButtonScript : MonoBehaviour
{
    public TextMeshProUGUI textGUI;
    public Button button;
    public float delay = 5.00f;

    /**
    * @brief Disables the button and starts the coroutine to get a new word from the API
    */
    public void NewWord()
    {
        button.interactable = false;
        button.GetComponentInChildren<Text>().text = "pls wait 5 sec :<";
        StartCoroutine(getRequest(APIHelper.API_URL + APIHelper.Base64Decode(APIHelper.API_KEY)));
    }

    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + JsonUtility.FromJson<Word>(uwr.downloadHandler.text).word);
            Word apiWord = JsonUtility.FromJson<Word>(uwr.downloadHandler.text);
            textGUI.text = GameManager.censorWord(apiWord.word);
            GameManager.currentWord = apiWord.word;
            yield return new WaitForSeconds(delay);
            button.interactable = true;
            button.GetComponentInChildren<Text>().text = "clicc me :D";
        }
    }
}
