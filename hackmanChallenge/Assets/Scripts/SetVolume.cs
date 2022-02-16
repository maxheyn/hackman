using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    // Set the volume of the mixer logarithmically so it is more accurate to the display of the slider.
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    void Start()
    {
        SetLevel(0.05f); // Set default volume so your ears don't bleed
    }
}
