using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SusScript : MonoBehaviour
{
    GameObject susObjekt;
    NavMeshAgent agent;
    public GameObject spillerTing;
    public SpillerMovementScript spiller;
    PhaseManager phaseManager;
    private void Start()
    {
        phaseManager = GetComponent<PhaseManager>();
    }
    private void Awake()
    {
        spillerTing = GameObject.FindGameObjectWithTag("spillerParent");
        if (spillerTing == null)
        {
            spillerTing = GameObject.FindGameObjectWithTag("hidden");
        }
        spiller = spillerTing.GetComponent<SpillerMovementScript>();
        spiller.SusDrop();
        susObjekt = GameObject.FindGameObjectWithTag("sus");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = susObjekt.transform.position;
        if ((Vector3.Distance(transform.position, susObjekt.transform.position) <= 2f))
        {
            Destroy(susObjekt);
        }

    }
}
