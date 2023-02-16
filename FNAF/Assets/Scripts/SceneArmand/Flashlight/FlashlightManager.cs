using System;
using System.Collections;
using System.Collections.Generic;
using SceneArmand.Flashlight;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = System.Random;

public class FlashlightManager : MonoBehaviour
{
    [Header("Instance")]
    public GameObject BrightLight;
    public GameObject FadeLight;
    public GameObject ObscureLight;
    public AudioClip SwitchOnOffSound;
    public AudioClip KnockDownSound;
    public AudioClip FlickingSound;

    [SerializeField] private GameObject _currentLight;
    
    [Header("GD")]
    public float BatteryDuration;
    public float BatteryCoefficient;
    public LightState LightState;
    public List<float> LightStateTimings = new List<float>();
    public int[] FlickingTimingRange;

    [SerializeField]private bool _isOn;

    private SoundManager _soundManager;
    private float _timeBeforeFlicking;
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(LightAction);

        _currentLight = BrightLight;
        
        _currentLight.SetActive(false);
        LightState = LightState.Bright;
        _isOn = false;

        Random rd = new Random();
        _timeBeforeFlicking = rd.Next(FlickingTimingRange[0], FlickingTimingRange[1]);
    }

    private void Update()
    {
        if (_isOn)
        {
            _timeBeforeFlicking -= Time.deltaTime;
            if (_timeBeforeFlicking <= 0)
            {
                FlickLight();
            }
            
            if (LightState != LightState.Obscure)
            {
                BatteryDuration -= Time.deltaTime;
                UpdateLightState();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BatteryComponent>())
        {
            Destroy(other.gameObject);
            BatteryDuration += BatteryCoefficient;
            UpdateLightState();
        }

        if (other.gameObject.GetComponent<GroundComponent>())
        {
            _soundManager.PlayAudioClip(KnockDownSound);
        }
    }

    private void UpdateLightState()
    {
        if (BatteryDuration > LightStateTimings[0] && LightState != LightState.Bright)
        {
            _currentLight.SetActive(false);
            LightState = LightState.Bright;
            _currentLight = BrightLight;
            _currentLight.SetActive(true);
        }
        else if (BatteryDuration <= LightStateTimings[0] && BatteryDuration > LightStateTimings[1] && LightState != LightState.Fade)
        {
            _currentLight.SetActive(false);
            LightState = LightState.Fade;
            _currentLight = FadeLight;
            _currentLight.SetActive(true);
        }
        else if (BatteryDuration <= LightStateTimings[1] && LightState != LightState.Obscure)
        {
            _currentLight.SetActive(false);
            LightState = LightState.Obscure;
            _currentLight = ObscureLight;
            _currentLight.SetActive(true);
        }
    }
    
    private void LightAction(ActivateEventArgs arg)
    {
        if (_isOn)
            TurnOffLight();
        else
            TurnOnLight();
        
        if (SwitchOnOffSound != null)
        {
            _soundManager.PlayAudioClip(SwitchOnOffSound);
        }
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

    private void FlickLight()
    {
        
    }

    private IEnumerator FlickOnOff()
    {
        _currentLight.SetActive(!_currentLight.activeSelf);
        yield return new WaitForSeconds(0.2f);
    }
}
