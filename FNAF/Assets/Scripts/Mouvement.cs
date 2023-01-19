using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Mouvement : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private CharacterController _character;
    private float _fallingSpeed;
    private XROrigin rig;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        bool IsGrounded = CheckIfGrounded();
        if (IsGrounded)
            _fallingSpeed = 0;
        else
        {
            _fallingSpeed += _gravity * Time.fixedDeltaTime;
            _character.Move(Vector3.up * _fallingSpeed * Time.fixedDeltaTime);
        }
    }

     
    private bool CheckIfGrounded()
    {
        Vector3 RayStart = transform.TransformPoint(_character.center);
        float RayLength = _character.center.y + 0.01f;
        bool HasHit = Physics.SphereCast(RayStart, _character.radius, Vector3.down, out RaycastHit HitInfo, RayLength, _groundLayer);
        return HasHit;
    }
}
