using System;
using System.Collections;
using System.Collections.Generic;
using SceneArmand.Flashlight;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashlightManager : MonoBehaviour
{
    [Header("Instance")]
    public GameObject BrightLight;
    public GameObject FadeLight;
    public GameObject ObscureLight;

    [SerializeField]private GameObject _currentLight;
    
    [Header("GD")]
    public float BatteryDuration;
    public float BatteryCoefficient;
    public LightState LightState;
    public List<float> LightStateTimings = new List<float>();

    [SerializeField]private bool _isOn;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(LightAction);

        _currentLight = BrightLight;
        
        _currentLight.SetActive(false);
        LightState = LightState.Bright;
        _isOn = false;
    }

    private void Update()
    {
        if (_isOn && LightState != LightState.Obscure)
        {
            BatteryDuration -= Time.deltaTime;
            UpdateLightState();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BatteryComponent>())
        {
            Destroy(other);
            BatteryDuration += BatteryCoefficient;
            UpdateLightState();
        }
    }

    private void UpdateLightState()
    {
        if (BatteryDuration > LightStateTimings[0])
        {
            LightState = LightState.Bright;
            _currentLight = BrightLight;
        }
        else if (BatteryDuration <= LightStateTimings[0] && BatteryDuration > LightStateTimings[1])
        {
            LightState = LightState.Fade;
            _currentLight = FadeLight;
        }
        else
        {
            LightState = LightState.Obscure;
            _currentLight = ObscureLight;
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
        _currentLight.SetActive(true);
        _isOn = true;
    }

    private void TurnOffLight()
    {
        _currentLight.SetActive(false);
        _isOn = false;
    }
}
