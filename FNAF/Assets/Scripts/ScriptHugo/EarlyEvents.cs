using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyEvents : MonoBehaviour
{
    public GameObject Door;
    public GameObject[] Lights;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        switch (GameManager.Instance.TurnCount)
        {
            case 3:
                Door.transform.GetChild(0).transform.GetComponentInChildren<Door>().OpenDoor();
                this.gameObject.SetActive(false);
                StartCoroutine(DoorEventEnd());
                break;
            default:
                break;
        }


        
    }

    IEnumerator DoorEventEnd() {
        yield return new WaitForSeconds(3f);
        Door.transform.GetChild(0).transform.GetComponentInChildren<Door>().ShutDoor();
    }
}
