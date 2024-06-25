using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    [Range(0f,1f)] public float bGMVol;
    [Range(0f, 1f)] public float sFXVol;

    public GameObject bGMSlider;
    public GameObject sFXSlider;

    private void Awake()
    {
        bGMSlider.GetComponent<Slider>().value = bGMVol;
        sFXSlider.GetComponent<Slider>().value = sFXVol;
        SoundManager.instance.musicVol = bGMVol;
        SoundManager.instance.sFXVol = sFXVol;
    }

    public void BGMVol()
    {
        bGMVol = bGMSlider.GetComponent<Slider>().value;
        SoundManager.instance.musicVol = bGMVol;
        SoundManager.instance.musicAudioSource.volume = bGMVol;
    }

    public void SFXVol()
    {
        sFXVol = sFXSlider.GetComponent<Slider>().value;
        SoundManager.instance.sFXVol = sFXVol;
    }
}
