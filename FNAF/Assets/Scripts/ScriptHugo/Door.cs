using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource[] _doorShutSound;
    private bool _isShutting = false;
    private float _shutForce = 0;
    public void ShutDoor(float force)
    {
        _isShutting= true;
        _doorShutSound[Random.Range(0, 2)].Play();
        _shutForce= force;
    }

    private void FixedUpdate()
    {
        if(_isShutting) this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*_shutForce, ForceMode.Impulse);
        _isShutting = false;
    }
}
