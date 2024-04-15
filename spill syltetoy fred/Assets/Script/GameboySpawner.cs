using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameboySpawner : MonoBehaviour
{
    public GameObject Gameboy;
    public Transform location1;
    public Transform location2;

    void Start()
    {
        SpawnObjectRandomly();
    }


    void SpawnObjectRandomly()
    {
        int randomNumber = Random.Range(0, 2);

        Vector3 spawnPosition = randomNumber == 0 ? location1.position : location2.position;
        
        Instantiate(Gameboy, spawnPosition, Quaternion.identity);
    }
}
