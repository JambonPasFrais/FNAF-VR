using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraControl : MonoBehaviour
{
    private XROrigin _origin;
    private CharacterController _character;
    public float additionalHeight = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowHeadset();
    }

    private void FollowHeadset()
    {
        _character.height = _origin.CameraInOriginSpaceHeight+ additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(_origin.Camera.gameObject.transform.position);
        _character.center = new Vector3(capsuleCenter.x, _character.height/2 + _character.skinWidth, capsuleCenter.z);
    }
}
