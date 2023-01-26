using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableHandlerHandling : MonoBehaviour
{
    private Transform _target;
    private Rigidbody _rb;
    private bool _reset;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _target.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_reset)
        {
            _rb.MovePosition(_target.transform.position);
        }
    }

    public void ResetPosition()
    {
        _reset = true;
    }
}
