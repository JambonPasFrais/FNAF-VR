using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportHallWay : MonoBehaviour
{
    [Header("Teloprtation Informations")]
    public GameObject Hallway;  // Hallway to teleport
    public Transform HTPPoint;  // Hallway Teleportation Point
    public GameObject BackWallsRoom;

    float _rotation = 0;

    //public Door ClosedDoor;

    public GameObject NextDetection;

    GameManager _gameManager;

    public Door DoorToShut;

    int _nbOfTP = 0;

    [Header("Doors Teleportation")]
    public List<GameObject> DoorsToTeleport = new List<GameObject>();
    public GameObject DoorPrefab;

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
            BackWallsRoom.SetActive(false);

            _nbOfTP = _nbOfTP % 2;

            if (DoorToShut != null)
                DoorToShut.ShutDoor();

            StartCoroutine(WaitBeforeContinue());
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

        Hallway.transform.rotation = Quaternion.Euler(0, _rotation, 0);

        if (_nbOfDoors > 0)
        {

            for (int i = 0; i < _nbOfDoors; i++)
            {
                GameObject go = Instantiate(DoorPrefab, _doorTransforms[i]);
                go.transform.SetParent(DoorsToTeleport[i].transform);

                if(i == 0) DoorToShut = go.GetComponentInChildren<Door>();
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
