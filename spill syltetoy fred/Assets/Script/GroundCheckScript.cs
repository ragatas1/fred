using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    public bool grounded;
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
        if (other.gameObject.tag == "ground")
        {
            grounded = true;
            Debug.Log("ja");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
