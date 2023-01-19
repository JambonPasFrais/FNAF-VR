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
    private float _fallingSpeed;
    private XROrigin rig;
    private CharacterController character;

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
            character.Move(Vector3.up * _fallingSpeed * Time.fixedDeltaTime);
        }
    }

    private bool CheckIfGrounded()
    {
        Vector3 RayStart = transform.TransformPoint(character.center);
        float RayLength = character.center.y + 0.01f;
        bool HasHit = Physics.SphereCast(RayStart, character.radius, Vector3.down, out RaycastHit HitInfo, RayLength, _groundLayer);
        return HasHit;
    }
}
