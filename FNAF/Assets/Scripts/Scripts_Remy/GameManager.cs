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
    public GameObject[] LockedDoorsGO;
    public int NbOfTeleportations = 0;

    System.Random rand = new System.Random();
    List<Transform> _lockedDoorsPosition = new List<Transform>();

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        foreach (var doors in LockedDoorsGO)
        {
            _lockedDoorsPosition.Add(doors.transform);
        }
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
        Destroy(LockedDoorsGO[NbOfTeleportations % 2].transform.GetChild(0).gameObject);

        GameObject go = Instantiate(LockedDoorPrefab, _lockedDoorsPosition[NbOfTeleportations % 2]);
        go.transform.SetParent(LockedDoorsGO[NbOfTeleportations % 2].transform);
    }
}
