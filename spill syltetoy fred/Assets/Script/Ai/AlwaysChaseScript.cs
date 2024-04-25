using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AlwaysChaseScript : MonoBehaviour
{
    GameObject spiller;
    NavMeshAgent agent;
    [HideInInspector] public float rubberBanding;
    public float rubberBandingSpeed;
    public float ja;

    // Start is called before the first frame update
    void Start()
    {
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
        agent.destination = spiller.transform.position;

        if ((Vector3.Distance(transform.position, spiller.transform.position) <= 1f))
        {
            SceneManager.LoadScene("fanget");
        }
        if ((Vector3.Distance(transform.position, spiller.transform.position) <= 10f))
        {
            rubberBanding = rubberBandingSpeed;
        }
        if ((Vector3.Distance(transform.position, spiller.transform.position) <= 20))
        {
            rubberBanding = rubberBandingSpeed*2;
        }
        else
        {
            rubberBanding = 1;
        }
        ja = (Vector3.Distance(transform.position, spiller.transform.position));

    }
}
