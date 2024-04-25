using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysChaseZone : MonoBehaviour
{
    public PhaseManager PhaseManager;
    bool ja;

    private void OnTriggerEnter(Collider spiller)
    {
        if(spiller.tag == "spiller")
        {
            ja=true;
        }
    }
    private void Update()
    {
        if( ja ) 
        {
            PhaseManager.phase = 5;
        }
    }
}
