using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHallWay : MonoBehaviour
{
    public GameObject Hallway;

    public Transform HTPPoint;  //Hallway Teleportation Point

    float rotation = 0;

    //public Door ClosedDoor;

    public GameObject NextDetection;

    GameManager _gameManager;

    public GameObject[] DoorParents;

    int _nbOfTP = 0;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        _nbOfTP = _nbOfTP % 2;

        DoorParents[_nbOfTP].GetComponentInChildren<Door>().ShutDoor();
        

        StartCoroutine(WaitBeforeContinue());
    }

    IEnumerator WaitBeforeContinue()
    {
        yield return new WaitForSeconds(5f);

        _gameManager.IsTeleporting = true;

        Hallway.transform.position = HTPPoint.position;

        rotation += 90;

        Hallway.transform.rotation = Quaternion.Euler(0, rotation, 0);

        NextDetection.SetActive(true);

        gameObject.SetActive(false);
    }
}
