using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{
    public AudioMixer am;
    public Slider MusicSlider;

    public void AudioVolume ()
        {
            am.SetFloat("Param", MusicSlider.value);
        }
}
