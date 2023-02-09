using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource[] _doorShutSound;
    [SerializeField] private AudioSource[] _doorMovingSound;
    private bool _isShutting = false;
    public float force;
    public void ShutDoor()
    {
        _isShutting= true;
        _doorShutSound[Random.Range(0, 2)].Play();
        GetComponent<XRGrabInteractable>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("shut");
            ShutDoor();
        }
        if(GetComponent<Rigidbody>().velocity != new Vector3(0, 0, 0))
        {
            _doorMovingSound[Random.Range(0, 2)].Play();
        }
        
    }
    private void FixedUpdate()
    {
        if(_isShutting) this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*force, ForceMode.Impulse);
        _isShutting = false;
    }
}
