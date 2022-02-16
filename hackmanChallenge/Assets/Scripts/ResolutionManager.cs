using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    // array of 16:9 resolutions
    private int[][] resolutions = new int[][] {
        new int[2] {1024, 576},
        new int[2] {1152, 648},
        new int[2] {1280, 720},
        new int[2] {1366, 768},
        new int[2] {1600, 900},
        new int[2] {1920, 1080},
        new int[2] {2560, 1440},
    };

    void Start()
    {
        // Set default resolution
        Screen.SetResolution(resolutions[0][0], resolutions[0][1], Screen.fullScreen);
    }

    public void ChangeResolution(int val)
    {
        // set new resolution
        Screen.SetResolution(resolutions[val][0], resolutions[val][1], Screen.fullScreen);
        Debug.Log("Resolution changed to " + resolutions[val][0] + "x" + resolutions[val][1]);
    }
}
