using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillerPickup : MonoBehaviour
{
    public bool HarGameboy;
    public bool GameBoyPlukkOpp;
    public GameObject Gameboy;
    void Start()
    {
        HarGameboy = false;
    }

    void Update()
    {
        if (GameBoyPlukkOpp == true) 
        {
            if (Input.GetButtonDown("Interact"))
            {
                HarGameboy = true;
                Gameboy.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gameboy")
        { 
            GameBoyPlukkOpp = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gameboy") 
        {  
            GameBoyPlukkOpp = false; 
        }
    }
}
