using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 12f;
    public float MouseSensitivity = 100f;
    public Transform PlayerBody;

    float _xRot = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        Controller.Move(move * Speed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        _xRot -= mouseY;
        _xRot = Mathf.Clamp(_xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}