using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SoundEffectSwitcher : MonoBehaviour
{
    public AudioClip[] SoundEffects;
    
    private void OnTriggerEnter(Collider other)
    {
        if (SoundEffects.Length >= 1)
        {
            //Choose Sound Effect
            Random rd = new Random();
            int randomIndex = rd.Next(0, SoundEffects.Length - 1);
            AudioClip choice = SoundEffects[randomIndex];
            
            //Create Game Object
            GameObject go = new GameObject();
            go.name = choice.name;
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = choice;
            source.Play();
            
            //Handle after Sound
            GameObject.Destroy(go, source.clip.length);
            gameObject.SetActive(false);
        }
    }
}
