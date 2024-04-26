using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class flyttMotCheckpointScript : MonoBehaviour
{
    GameObject test;
    NextLevel nextLevel;
    public Vector3 sted;
    PhaseManager phaseManager;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        phaseManager = GetComponent<PhaseManager>();
        test = GameObject.FindGameObjectWithTag("logikk");
        nextLevel = test.GetComponent<NextLevel>();
        if (nextLevel.bane3Checkpoint)
        {
            agent.Warp(sted);
            phaseManager.phase = 0;
        }
    }
    private void Update()
    {
        if (nextLevel.bane3Checkpoint)
        {
            if (phaseManager.phase == 1)
            {
                phaseManager.phase = 0;
            }
        }

    }
}
