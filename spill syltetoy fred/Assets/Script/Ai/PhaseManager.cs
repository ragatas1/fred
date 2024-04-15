using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public int phase;
    PatrolScript phase1;
    SusScript phase2;
    ChaseScript phase3;
    // Start is called before the first frame update
    void Start()
    {
        phase1 = GetComponent<PatrolScript>();
        phase2 = GetComponent<SusScript>();
        phase3 = GetComponent<ChaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)  { phase1.enabled = true; }
        else { phase1.enabled = false; }

        if (phase == 2) { phase2.enabled = true; }
        else { phase2.enabled = false; }

        if (phase == 3) { phase3.enabled = true; }
        else { phase3.enabled = false; }
    }
}
