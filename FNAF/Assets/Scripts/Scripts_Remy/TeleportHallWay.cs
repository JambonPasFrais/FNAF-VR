using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHallWay : MonoBehaviour
{
    public GameObject Hallway;
    public GameObject TransitionHallway;

    public Transform THTPPoint; //Transition Hallway Teleportation Point
    public Transform HTPPoint;  //Hallway Teleportation Point

    public GameObject BackWalls;
    public GameObject FrontWalls;


    private void OnTriggerEnter(Collider other)
    {
        
    }
}