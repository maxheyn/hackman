using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System.Runtime.InteropServices;

public class ExitGame : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void openWindow(string url);
    // Code for the exit button, depending on the platform it will either quit the game or open a new tab.
    public void doExitGame()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #elif (UNITY_WEBGL)
            // Open a new tab in the browser.
            //Application.OpenURL("https://github.com/maxheyn/hackman");
            openWindow("https://github.com/maxheyn/hackman");
        #endif
    }
}
