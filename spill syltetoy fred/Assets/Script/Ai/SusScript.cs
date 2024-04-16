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

    private void OnEnable()
    {
        if (phaseManager == null){phaseManager = GetComponent<PhaseManager>();}
        if (spillerTing == null) {spillerTing = GameObject.FindGameObjectWithTag("spillerParent");}
        if (spiller == null) {spiller = spillerTing.GetComponent<SpillerMovementScript>();}
        if (agent == null) {agent = GetComponent<NavMeshAgent>();}

        spiller.SusDrop();
        susObjekt = GameObject.FindGameObjectWithTag("sus");
    }
    private void OnDisable()
    {
        Destroy(susObjekt);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = susObjekt.transform.position;
        if ((Vector3.Distance(transform.position, susObjekt.transform.position) <= 2f))
        {
            phaseManager.phase = 1;
        }

    }
}
