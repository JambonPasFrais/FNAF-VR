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

        if(GameManager.Instance.TurnCount == 3) 
        {
            Destroy(GameManager.Instance.DoorTVRoom.transform.GetChild(0).gameObject);
            
            GameObject go = Instantiate(GameManager.Instance.DoorPrefab, GameManager.Instance.DoorTVRoom.transform);
            go.transform.SetParent(GameManager.Instance.DoorTVRoom.transform);  
            
            StartCoroutine(OpenDoorWait(go));
        }

        else if(GameManager.Instance.TurnCount == 4)
        {
            Destroy(GameManager.Instance.DoorTVRoom.transform.GetChild(0));

            GameObject go = Instantiate(GameManager.Instance.LockedDoorPrefab);
            go.transform.SetParent(GameManager.Instance.DoorTVRoom.transform);
        }

        IEnumerator OpenDoorWait(GameObject go)
        {
            yield return new WaitForSeconds(5f);

            go.transform.GetComponentInChildren<Door>().OpenDoor();

            gameObject.SetActive(false);
        }

        IEnumerator StopSound(int source, float time)
        {
            yield return new WaitForSeconds(time);
            _sources[source].Stop();
            gameObject.SetActive(false);
        }
    }
}
