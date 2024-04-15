using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseScript : MonoBehaviour
{

    private NavMeshAgent agent;
    GameObject spiller;
    PhaseManager phaseManager;
    public VisionCone2 vision;
    public float sinnaTid;
    float tid;
    // Start is called before the first frame update
    void Start()
    {
        phaseManager = GetComponent<PhaseManager>();
        spiller = GameObject.FindGameObjectWithTag("spiller");
        if (spiller == null)
        {
            spiller = GameObject.FindGameObjectWithTag("hidden");
        }
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( vision.ser == true)
        {
            tid = 0;
            vision.ser = false;
        }
        tid = tid + 1*Time.deltaTime;
        if ( tid > sinnaTid )
        {
            phaseManager.phase = 2;
        }

        agent.destination = spiller.transform.position;
        if ((Vector3.Distance(transform.position, spiller.transform.position) <= 2f))
        {

        }

    }
}
