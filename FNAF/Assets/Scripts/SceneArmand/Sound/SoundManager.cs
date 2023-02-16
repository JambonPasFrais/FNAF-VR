using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    public void PlayAudioClip(AudioClip clip)
    {
        //Create Game Object
        GameObject go = new GameObject();
        go.name = clip.name;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
            
        //Handle after Sound
        GameObject.Destroy(go, source.clip.length);
    }

    public void LoopAudioClip(AudioClip clip)
    {
        //Create Game Object
        GameObject go = new GameObject();
        go.name = clip.name;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        source.loop = true;
    }
}
