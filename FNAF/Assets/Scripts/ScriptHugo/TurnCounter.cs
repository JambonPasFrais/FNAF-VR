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
                foreach (GameObject light in GameManager.Instance.Lights)
                {
                    if(GameManager.Instance.Lights.IndexOf(light) != 2 || GameManager.Instance.Lights.IndexOf(light) != 4)
                    {
                        light.GetComponent<Light>().intensity = 0;
                    }
                }
                break;
                case 4:
                foreach (GameObject light in GameManager.Instance.Lights)
                {
                    light.GetComponentInChildren<Light>().color = new Color(255, 127, 127);
                }
                break;
            default:
                break;
        }
    }
}
