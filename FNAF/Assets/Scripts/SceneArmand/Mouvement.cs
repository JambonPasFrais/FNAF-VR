using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Mouvement : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private CharacterController _character;
    private float _fallingSpeed;
    [SerializeField] private XROrigin rig;
    public float AdditionalHeight = 0.02f;

    public GameObject Screamer;

    private void OnTriggerEnter(Collider other)
    {
        Screamer.SetActive(true);
    }


    private void FixedUpdate()
    {
        FollowHeadset();
        bool IsGrounded = CheckIfGrounded();
        if (IsGrounded)
            _fallingSpeed = 0;
        else
        {
            _fallingSpeed += _gravity * Time.fixedDeltaTime;
            _character.Move(Vector3.up * _fallingSpeed * Time.fixedDeltaTime);
        }
    }

    void FollowHeadset()
    {
        _character.height = rig.CameraInOriginSpaceHeight + AdditionalHeight;
        Vector3 CapsuleCenter = transform.InverseTransformPoint(rig.Camera.gameObject.transform.position);
        _character.center = new Vector3(CapsuleCenter.x, _character.height / 2 + _character.skinWidth, CapsuleCenter.z);
    }
    private bool CheckIfGrounded()
    {
        Vector3 RayStart = transform.TransformPoint(_character.center);
        float RayLength = _character.center.y + 0.01f;
        bool HasHit = Physics.SphereCast(RayStart, _character.radius, Vector3.down, out RaycastHit HitInfo, RayLength, _groundLayer);
        return HasHit;
    }
}
