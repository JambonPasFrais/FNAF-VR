using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public AudioClip Clip;
    public AudioSource Source;
    public GameObject LockedDoorPrefab;
    public GameObject LockedDoorsGO;
    public int NbOfTeleportations = 0;
    public GameObject WallLockedDoor;
    public Collider MiddleHallwayEventCollider;
    public Collider StartHallwayEventCollider;
    public int TurnCount = 0;

    System.Random rand = new System.Random();
    Transform _lockedDoorsPosition;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        _lockedDoorsPosition = LockedDoorsGO.transform;
    }

    void Start()
    {
        Source.clip = Clip;
        //StartCoroutine("PlaySound", rand.Next(3, 10));
    }

    IEnumerator PlaySound(int time)
    {
        yield return new WaitForSeconds(time);
        Source.clip = Clip;
        Source.Play();
        StartCoroutine("PlaySound", rand.Next(3, 10));
    }

    public void LockTheDoor()
    {
        if (NbOfTeleportations % 2 == 1)
        {
            WallLockedDoor.SetActive(false);
            Destroy(LockedDoorsGO.transform.GetChild(0).gameObject);

            GameObject go = Instantiate(LockedDoorPrefab, _lockedDoorsPosition);
            go.transform.SetParent(LockedDoorsGO.transform);
        }
        else WallLockedDoor.SetActive(true);

        
    }

  


}
