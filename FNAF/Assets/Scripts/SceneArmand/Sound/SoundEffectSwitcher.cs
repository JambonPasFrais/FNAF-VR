using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SoundEffectSwitcher : MonoBehaviour
{
    public AudioClip[] SoundEffects;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = new SoundManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SoundEffects.Length >= 1)
        {
            //Choose Sound Effect
            Random rd = new Random();
            int randomIndex = rd.Next(0, SoundEffects.Length - 1);
            AudioClip choice = SoundEffects[randomIndex];

            _soundManager.PlayAudioClip(choice);
            
            gameObject.SetActive(false);
        }
    }
}
