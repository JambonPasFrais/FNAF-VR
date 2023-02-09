using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioClip[] _doorShutSound;
    [SerializeField] private AudioClip[] _doorMovingSound;
    [SerializeField] private AudioSource Sound;
    [SerializeField] private AudioSource _currentSound;
    private bool _isShutting = false;
    public float force;
    
    public void ShutDoor()
    {
        _isShutting= true;
        Sound.clip =_doorShutSound[Random.Range(0, 2)];
        Sound.Play();
        GetComponent<XRGrabInteractable>().enabled = false;
    }

 
    private void Update()
    {
        if (GetComponent<Rigidbody>().velocity != new Vector3(0, 0, 0) && _currentSound.clip == null)
        {
            Debug.Log("move");
           _currentSound.clip =  _doorMovingSound[Random.Range(0, 2)];
            _currentSound.Play();
        }
       

        else if(GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0) && _currentSound != null && _currentSound.isPlaying)
        {
            _currentSound.Stop();
            _currentSound.clip = null;
        }
       
        
    }
    private void FixedUpdate()
    {
        if(_isShutting) this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*force, ForceMode.Impulse);
        _isShutting = false;
        
    }
    
}
