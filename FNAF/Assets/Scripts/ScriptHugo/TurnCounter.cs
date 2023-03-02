using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCounter : MonoBehaviour
{
    public GameObject[] Events;
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
    }
}
