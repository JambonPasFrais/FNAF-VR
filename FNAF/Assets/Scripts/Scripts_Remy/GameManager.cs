using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip Clip;
    public AudioSource Source;
    System.Random rand = new System.Random();

    public static GameManager Instance;

    public bool IsTeleporting = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        Source.clip = Clip;
        //StartCoroutine("PlaySound", rand.Next(3, 10));
    }

    IEnumerator PlaySound(int time)
    {
        yield return new WaitForSeconds(time);
        Source.clip = Clip;
        Source.Play();
        StartCoroutine("PlaySound", rand.Next(3, 10));
    }
}
