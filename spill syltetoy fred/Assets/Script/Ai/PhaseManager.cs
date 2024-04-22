using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PhaseManager : MonoBehaviour
{
    public int phase;
    PatrolScript phase1;
    SusScript phase2;
    ChaseScript phase3;
    LookAroundScript phase4;
    public float speed;
    public float chasespeed;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        phase1 = GetComponent<PatrolScript>();
        phase2 = GetComponent<SusScript>();
        phase3 = GetComponent<ChaseScript>();
        phase4 = GetComponent<LookAroundScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)  
        {
            phase1.enabled = true; Debug.Log("fase1");
            navMeshAgent.speed = speed;
        }
        else { phase1.enabled = false; }
        navMeshAgent.speed = speed;
        //phase 1 er patruljeringsfasen

        if (phase == 2) 
        {
            phase2.enabled = true; Debug.Log("fase2");
            navMeshAgent.speed = speed;
        }
        else { phase2.enabled = false; }
        //phase 2 er susfasen

        if (phase == 3) 
        {
            phase3.enabled = true; Debug.Log("fase3");
            navMeshAgent.speed = chasespeed;
        }
        else { phase3.enabled = false; }
        //phase 3 er chasefasen

        if (phase == 4)
        {
            phase4.enabled = true; Debug.Log("fase4");
            navMeshAgent.speed = speed;
        }
        else { phase4.enabled = false; }
        //phase 3 se seg rundt fasen
    }
}
