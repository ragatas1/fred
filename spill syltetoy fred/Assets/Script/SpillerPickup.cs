using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillerPickup : MonoBehaviour
{
    public bool HarGameboy;
    public bool GameBoyPlukkOpp;
    public GameObject Gameboy;
    public GameObject txt;
    public GameObject txt2;
    public float ventetid;
    void Start()
    {
        Gameboy = GameObject.FindGameObjectWithTag("Gameboy");
        HarGameboy = false;
        txt.SetActive(false);
    }

    void Update()
    {
        if (GameBoyPlukkOpp == true) 
        {
            if (Input.GetButtonDown("Interact"))
            {
                HarGameboy = true;
                Gameboy.SetActive(false);
                GameBoyPlukkOpp = false;
                StartCoroutine(text());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gameboy")
        { 
            GameBoyPlukkOpp = true; 
            txt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gameboy") 
        {  
            GameBoyPlukkOpp = false; 
            txt.SetActive(false);
        }
    }
    IEnumerator text()
    {
        txt.SetActive(false);
        txt2.SetActive(true);
        yield return new WaitForSeconds(ventetid);
        txt2.SetActive(false);
    }
}
