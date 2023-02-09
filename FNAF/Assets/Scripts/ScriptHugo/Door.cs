using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource[] _doorShutSound;
    private bool _isShutting = false;
    private float _shutForce = 0;

    public DoorParent DoorParentRef;

    public void ShutDoor()
    {
        _isShutting= true;
        _doorShutSound[Random.Range(0, 2)].Play();
        _shutForce = Random.Range(3, 10);

        DoorParentRef.RestoreDoor();

        //  GetComponent<XRGrabInteractable>().enabled = false;
    }

    private void FixedUpdate()
    {
        if(_isShutting) this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*_shutForce, ForceMode.Impulse);
        _isShutting = false;
    }
}
