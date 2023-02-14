using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorParent : MonoBehaviour
{
    public List<GameObject> Doors = new List<GameObject>();
    public GameObject DoorPrefab;

    [SerializeField] List<Vector3> _doorPositions = new List<Vector3>();
    [SerializeField] List<Transform> _doorTransforms = new List<Transform>();
    [SerializeField] List<Quaternion> _doorRotations = new List<Quaternion>();
    [SerializeField] int _nbOfDoors;

    private void Awake()
    {
        foreach(var door in Doors)
        {
            _doorPositions.Add(door.transform.position);
            _doorRotations.Add(door.transform.rotation);
            _doorTransforms.Add(door.transform);
        }

        _nbOfDoors = Doors.Count;
    }

    public void RestoreDoor()
    {
        foreach(var door in Doors)
        {
            Destroy(door);
            Doors.Remove(door);
            _doorPositions.Remove(door.transform.position);
            _doorRotations.Remove(door.transform.rotation);
            _doorTransforms.Remove(door.transform);
        }

        for (int i = 0; i < _nbOfDoors; i++)
        {
            GameObject go = Instantiate(DoorPrefab, _doorTransforms[i]);
        }

        foreach (var door in Doors)
        {
            _doorPositions.Add(door.transform.position);
            _doorRotations.Add(door.transform.rotation);
            _doorTransforms.Add(door.transform);
        }

        _nbOfDoors = Doors.Count;
    }
}
