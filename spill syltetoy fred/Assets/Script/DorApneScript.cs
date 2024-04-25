using BrokenVector.LowPolyFencePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DorApneScript : MonoBehaviour
{
    public DoorController door;
    public SpillerPickup spiller;
    bool vedDor;
    public BoxCollider box;
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vedDor && spiller.HarGameboy)
        {
            if (Input.GetButtonDown("Interact"))
            {
                door.OpenDoor();
                box.enabled = false;
                spiller.HarGameboy = false;
            }
            txt.SetActive(true);
        }
        else
        {
            txt.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spiller")
        {
            vedDor = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "spiller")
        {
            vedDor = false;
        }

    }
}
