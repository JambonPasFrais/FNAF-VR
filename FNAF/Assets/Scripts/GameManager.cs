using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip Clip;
    public AudioSource Source;
    
    void Start()
    {
        Source.clip = Clip;
        Source.Play();
    }
}
