using System;
using System.Collections;
using System.Collections.Generic;
using SceneArmand.Flashlight;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashlightManager : MonoBehaviour
{
    [Header("Instance")]
    public GameObject Light;

    [Header("GD")]
    public float BatteryDuration;
    public LightState LightState;
    public List<float> LightStateTimings = new List<float>();

    private bool _isOn;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(LightAction);

        Light.SetActive(false);
        LightState = LightState.Bright;
        _isOn = false;
    }

    private void Update()
    {
        if (_isOn)
        {
            BatteryDuration -= Time.deltaTime;
            if (BatteryDuration <= LightStateTimings[0] && BatteryDuration > LightStateTimings[1])
                LightState = LightState.Bright;
            else if (BatteryDuration <= LightStateTimings[1] && BatteryDuration > LightStateTimings[2])
                LightState = LightState.Fade;
            else
                LightState = LightState.Obscure;

        }
        
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
