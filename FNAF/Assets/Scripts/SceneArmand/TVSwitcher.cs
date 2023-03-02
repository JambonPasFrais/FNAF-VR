using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSwitcher : MonoBehaviour
{
    public GameObject TVLight;
    public AudioClip SoundEffect;
    
    SoundManager _soundManager;

    private void Start()
    {
        _soundManager = new SoundManager();
    }

    private void OnTriggerEnter(Collider other)
    {
        _soundManager.LoopAudioClip(SoundEffect);
        //gameObject.SetActive(false);
        TVLight.SetActive(true);
        GameManager.Instance.DoorTVRoom.transform.GetChild(0).GetComponentInChildren<Door>().ShutDoor();
        StartCoroutine(Continue());
    }

    IEnumerator Continue()
    {
        foreach (GameObject light in GameManager.Instance.Lights)
        {
            light.GetComponentInChildren<Light>().color = Color.red;
        }

        yield return new WaitForSeconds(10f);

        GameManager.Instance.DoorTVRoom.transform.GetChild(0).GetComponentInChildren<Door>().OpenDoor();
        _soundManager.StopSound();

        gameObject.SetActive(false);
    }
}