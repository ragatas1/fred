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

    
        Transform chosenLocation = randomNumber == 0 ? location1 : location2;

     
        Vector3 spawnPosition = chosenLocation.position;

        
        Quaternion spawnRotation = chosenLocation.rotation;

        Instantiate(Gameboy, spawnPosition, spawnRotation);
    }
}
