using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    AudioSource _source;

    public void PlayAudioClip(AudioClip clip)
    {
        //Create Game Object
        GameObject go = new GameObject();
        go.name = clip.name;
        _source = go.AddComponent<AudioSource>();
        _source.clip = clip;
        _source.Play();
            
        //Handle after Sound
        GameObject.Destroy(go, _source.clip.length);
    }

    public void LoopAudioClip(AudioClip clip)
    {
        //Create Game Object
        GameObject go = new GameObject();
        go.name = clip.name;
        _source = go.AddComponent<AudioSource>();
        _source.clip = clip;
        _source.loop = true;
        _source.Play();
    }

    public void StopSound()
    {
        _source.Stop();
    }
}
