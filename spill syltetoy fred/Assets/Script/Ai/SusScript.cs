using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SusScript : MonoBehaviour
{
    GameObject susObjekt;
    NavMeshAgent agent;
    GameObject spillerTing;
    SpillerMovementScript spiller;
    PhaseManager phaseManager;
    public float giOppTid;

    private void OnEnable()
    {
        if (phaseManager == null){phaseManager = GetComponent<PhaseManager>();}
        if (spillerTing == null) {spillerTing = GameObject.FindGameObjectWithTag("spillerParent");}
        if (spiller == null) {spiller = spillerTing.GetComponent<SpillerMovementScript>();}
        if (agent == null) {agent = GetComponent<NavMeshAgent>();}

        spiller.SusDrop();
        susObjekt = GameObject.FindGameObjectWithTag("sus");
        StartCoroutine(giOpp());
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
    IEnumerator giOpp()
    {
        yield return new WaitForSeconds(giOppTid);
        phaseManager.phase = 1;
    }
}
