using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInteractor : MonoBehaviour
{
    public GameObject DirectController;
    public GameObject RayController;
    
    private void OnTriggerEnter(Collider other)
    {
        DirectController.SetActive(true);
        RayController.SetActive(false);
    }
}
