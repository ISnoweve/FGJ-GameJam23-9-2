using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] BGMSounds, sfxSounds;
    public AudioSource BGMSource, sfxSource, UISourse;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PlayBGM("BGM");
    }
    public void PlayBGM(string name)
    {
        Sound s = Array.Find(BGMSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            BGMSource.clip = s.clip;
            BGMSource.Play();
        }
    }
  
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }


}
