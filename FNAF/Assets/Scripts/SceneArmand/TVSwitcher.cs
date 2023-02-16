using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSwitcher : MonoBehaviour
{
    public GameObject TVLight;
    public AudioClip SoundEffect;
    
    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = new SoundManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        _soundManager.LoopAudioClip(SoundEffect);
        gameObject.SetActive(false);
        TVLight.SetActive(true);
    }
}
