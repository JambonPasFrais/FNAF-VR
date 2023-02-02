using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHallWay : MonoBehaviour
{
    public GameObject Hallway;

    public Transform HTPPoint;  //Hallway Teleportation Point

    float rotation = 0;


    private void OnTriggerEnter(Collider other)
    {
        Hallway.transform.position = HTPPoint.position;

        rotation += 90;

        Hallway.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
