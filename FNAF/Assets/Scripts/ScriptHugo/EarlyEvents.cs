using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class EarlyEvents : MonoBehaviour
{
    public GameObject Door;
    private void OnTriggerEnter(Collider other)
    {
        switch (GameManager.Instance.TurnCount)
        {
            
            case 4:
                Door.transform.GetChild(0).transform.GetComponentInChildren<Door>().OpenDoor();
                StartCoroutine(DoorEventEnd());
                break;
            default:
                break;
        }


        
    }

    IEnumerator DoorEventEnd() {
        yield return new WaitForSeconds(3f);
        Door.transform.GetChild(0).transform.GetComponentInChildren<Door>().ShutDoor();
        this.gameObject.SetActive(false);
    }
}
