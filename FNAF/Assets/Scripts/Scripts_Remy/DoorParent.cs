using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorParent : MonoBehaviour
{
    public GameObject DoorBodyPrefab;
    GameObject _doorParentRef;
    [SerializeField] Vector3 _doorBodyPosition;
    [SerializeField] Quaternion _doorBodyRotation;

    private void Awake()
    {
        _doorParentRef = GetComponentInChildren<Door>().gameObject;
        _doorBodyPosition = _doorParentRef.transform.position;
        _doorBodyRotation = _doorParentRef.transform.rotation;
    }
    public void RestoreDoor()
    {
        Destroy(_doorParentRef);

        GameObject go = Instantiate(DoorBodyPrefab);
        go.transform.SetParent(transform, false);
        go.transform.localPosition = _doorBodyPosition;
        go.transform.localRotation = _doorBodyRotation;
    }
}
