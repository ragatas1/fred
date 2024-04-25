using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyttMotCheckpointScript : MonoBehaviour
{
    GameObject test;
    NextLevel nextLevel;
    public Vector3 sted;
    PhaseManager phaseManager;
    // Start is called before the first frame update
    void Start()
    {
        phaseManager = GetComponent<PhaseManager>();
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        if (nextLevel.bane3Checkpoint)
        {
            transform.position = sted;
            phaseManager.phase = 0;
        }
    }
}
