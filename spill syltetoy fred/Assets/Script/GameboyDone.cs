using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameboyDone : MonoBehaviour
{
    public bool iSenga;
    public SpillerPickup Gaeboy;
    public GameObject txt;
   
    void Start()
    {
        txt.SetActive(false);
    }

  
    void Update()
    {
        if (iSenga)
        {
            if(Gaeboy.HarGameboy == true)
            {
                txt.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {
                    SceneManager.LoadScene("WinScreen");
                }
            }
            else
            {
                txt.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spiller")
        {
            iSenga = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "spiller")
        {
            iSenga = false;
        }
    }
}
