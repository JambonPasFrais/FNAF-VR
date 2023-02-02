using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnOnLightOnActivate : MonoBehaviour
{
    public GameObject Light;
    private bool _isOn;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(LightAction);

        Light.SetActive(false);
        _isOn = false;
    }

    private void LightAction(ActivateEventArgs arg)
    {
        if (_isOn)
            TurnOffLight();
        else
            TurnOnLight();
    }
    
    private void TurnOnLight()
    {
        Light.SetActive(true);
        _isOn = true;
    }

    private void TurnOffLight()
    {
        Light.SetActive(false);
        _isOn = false;
    }
}
