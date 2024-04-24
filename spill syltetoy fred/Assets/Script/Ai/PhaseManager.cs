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
    AlwaysChaseScript phase5;
    public float speed;
    public float chaseSpeed;
    public float alwaysChaseSpeed;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        phase1 = GetComponent<PatrolScript>();
        phase2 = GetComponent<SusScript>();
        phase3 = GetComponent<ChaseScript>();
        phase4 = GetComponent<LookAroundScript>();
        phase5 = GetComponent<AlwaysChaseScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)  
        {
            phase1.enabled = true;
            navMeshAgent.speed = speed;
        }
        else { phase1.enabled = false; }
        navMeshAgent.speed = speed;
        //phase 1 er patruljeringsfasen

        if (phase == 2) 
        {
            phase2.enabled = true;
            navMeshAgent.speed = speed;
        }
        else { phase2.enabled = false; }
        //phase 2 er susfasen

        if (phase == 3) 
        {
            phase3.enabled = true; 
            navMeshAgent.speed = chaseSpeed;
        }
        else { phase3.enabled = false; }
        //phase 3 er chasefasen

        if (phase == 4)
        {
            phase4.enabled = true; 
            navMeshAgent.speed = speed;
        }
        else { phase4.enabled = false; }
        //phase 4 er se seg rundt fasen
        if (phase == 5)
        {
            phase5.enabled = true; 
            navMeshAgent.speed = alwaysChaseSpeed;
        }
        else
        {
            phase5.enabled = false;
        }
    }
}
