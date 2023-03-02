using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Events : MonoBehaviour
{
    public AudioClip[] GlassSoundEffects;
    public AudioClip[] DoorSoundEffects;
    public AudioSource[] _sources;

   
    private void OnTriggerEnter(Collider other)
    {
        if (GlassSoundEffects.Length >= 1 && GameManager.Instance.TurnCount == 1)
        {
            //Choose Sound Effect
            Random rd = new Random();
            int randomIndex = rd.Next(0, GlassSoundEffects.Length - 1);
            _sources[0].clip = GlassSoundEffects[randomIndex];

            _sources[0].Play();
            this.gameObject.SetActive(false);
        }

        if (DoorSoundEffects.Length >= 1 && GameManager.Instance.TurnCount == 2)
        {
            _sources[1].clip = DoorSoundEffects[0];
            _sources[1].Play();
            StartCoroutine(StopSound(1,1.1f));

        }

        if(GameManager.Instance.TurnCount == 4) {
           
        }

        IEnumerator StopSound(int source, float time)
        {
            yield return new WaitForSeconds(time);
            _sources[source].Stop();
            this.gameObject.SetActive(false);
        }
    }
}
