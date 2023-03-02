using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportHallWay : MonoBehaviour
{
    [Header("Telportation Informations")]
    public GameObject Hallway;  // Hallway to teleport
    public Transform HTPPoint;  // Hallway Teleportation Point
    public GameObject BackWallsRoom;

    float _rotation = 0;

    public GameObject[] FloorCrackingDetections;

    public GameObject NextDetection;

    GameManager _gameManager;

    public GameObject DoorToShut;

    int _nbOfTP = 0;

    [Header("Doors Teleportation")]
    public List<GameObject> DoorsToTeleport = new List<GameObject>();
    

    [SerializeField] List<Transform> _doorTransforms = new List<Transform>();
    [SerializeField] int _nbOfDoors;


    private void Awake()
    {
        _gameManager = GameManager.Instance;

        if(DoorsToTeleport != null)
            ActualiseDoors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _gameManager.NbOfTeleportations++;

            BackWallsRoom.SetActive(false);

            _nbOfTP = _nbOfTP % 2;

            if (DoorToShut != null)
                DoorToShut.transform.GetChild(0).transform.GetComponentInChildren<Door>().ShutDoor();

            StartCoroutine(WaitBeforeContinue());
            if(FloorCrackingDetections != null)
            {
                foreach (GameObject detection in FloorCrackingDetections)
                {
                    detection.SetActive(true);
                }
            }
        }
    }

    IEnumerator WaitBeforeContinue()
    {
        yield return new WaitForSeconds(1f);

        foreach(var door in DoorsToTeleport) 
        {
            Destroy(door.transform.GetChild(0).gameObject);
        }

        Hallway.transform.position = HTPPoint.position;

        _rotation += 90;

        _gameManager.LockTheDoor();

        Hallway.transform.rotation = Quaternion.Euler(0, _rotation, 0);

        if (_nbOfDoors > 0)
        {
            for (int i = 0; i < _nbOfDoors; i++)
            {
                GameObject go = Instantiate(GameManager.Instance.DoorPrefab, _doorTransforms[i]);
                go.transform.SetParent(DoorsToTeleport[i].transform);

            }
        }

        NextDetection.SetActive(true);

        gameObject.SetActive(false);
    }

    void ActualiseDoors()
    {
        foreach (var door in DoorsToTeleport)
        {
            _doorTransforms.Add(door.transform);
        }

        _nbOfDoors = DoorsToTeleport.Count;
    }
}
