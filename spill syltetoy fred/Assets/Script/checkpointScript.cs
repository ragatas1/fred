using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    GameObject test;
    NextLevel nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        nextLevel.bane3();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spiller")
        {
            Debug.Log("gjort");
            nextLevel.bane3Checkpoint = true;
        }
    }
}
