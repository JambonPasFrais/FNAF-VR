using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    public GameObject[] Events;
    public AudioSource source;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ++GameManager.Instance.TurnCount;
            foreach (GameObject obj in Events)
            {
                obj.gameObject.SetActive(true);
            }
        }

        switch (GameManager.Instance.TurnCount)
        {
            case 2:
                foreach (GameObject light in GameManager.Instance.Lights)
                {
                    light.GetComponentInChildren<Light>().intensity = 0.5f;
                }
                break;
            case 3:
                source.Play();

                for (int i = 0; i < GameManager.Instance.Lights.Count; i++)
                {
                    if (i == 2)
                        Debug.Log("Lampe 2");
                    else if (i == 4)
                        Debug.Log("Lampe 4");
                    else if (i == 7)
                        Debug.Log("Lampe 7");
                    else
                        GameManager.Instance.Lights[i].GetComponentInChildren<Light>().intensity = 0;
                }
               
                break;
            default:
                break;
        }
    }
}
