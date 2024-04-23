using BrokenVector.LowPolyFencePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorApneScript : MonoBehaviour
{
    public DoorController door;
    public SpillerPickup spiller;
    bool vedDor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
