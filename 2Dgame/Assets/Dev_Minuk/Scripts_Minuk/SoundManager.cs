using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField][Range(0f, 1f)] private float musicVol;
    [SerializeField][Range(0f, 1f)] private float sFXVol;
    [SerializeField][Range(0f, 1f)] private float sFXPitch;

    private AudioSource musicAudioSource;
    public AudioClip musicClip;

    private void Awake()
    {
        instance = this;
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.volume = musicVol;
        musicAudioSource.loop = true;
    }

    private void Start()
    {
        PlayBGM(musicClip);
    }

    public static void PlayBGM(AudioClip musicClip)
    {
        instance.musicAudioSource.Stop();
        instance.musicAudioSource.clip = musicClip;
        instance.musicAudioSource.Play();
    }

    public static void PlayClip(AudioClip clip)
    {
        GameObject obj = ObjectPool.Instance.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, instance.sFXVol, instance.sFXPitch);
    }
}
