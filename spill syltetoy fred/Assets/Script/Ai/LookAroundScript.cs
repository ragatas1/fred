using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAroundScript : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    public float randomRange;
    PhaseManager phaseManager;

    Vector3 target1;
    Vector3 target2;
    Vector3 target3;
    Vector3 target4;
    Vector3 target5;
    int targetNummer;
    public float ventetid;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        phaseManager = GetComponent<PhaseManager>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        targetNummer = 1;
        target1 = new Vector3(transform.position.x + Random.Range(-randomRange, randomRange), transform.position.y, transform.position.z + Random.Range(-randomRange, randomRange));
        target2 = new Vector3(transform.position.x + Random.Range(-randomRange, randomRange), transform.position.y, transform.position.z + Random.Range(-randomRange, randomRange));
        target3 = new Vector3(transform.position.x + Random.Range(-randomRange, randomRange), transform.position.y, transform.position.z + Random.Range(-randomRange, randomRange));
        target4 = new Vector3(transform.position.x + Random.Range(-randomRange, randomRange), transform.position.y, transform.position.z + Random.Range(-randomRange, randomRange));
        target5 = new Vector3(transform.position.x + Random.Range(-randomRange, randomRange), transform.position.y, transform.position.z + Random.Range(-randomRange, randomRange));

    }
    void Update()
    {
        if (targetNummer == 1)
        {
            _agent.SetDestination(target1);
            if ((Vector3.Distance(transform.position, target1))<2||timer>ventetid)
            {
                targetNummer = targetNummer + 1;
                timer = 0;
            }
        }
        else if (targetNummer == 2)
        {
            _agent.SetDestination(target2);
            if ((Vector3.Distance(transform.position, target2)) < 2 || timer > ventetid)
            {
                targetNummer = targetNummer + 1;
                timer = 0;
            }
        }
        else if (targetNummer == 3)
        {
            _agent.SetDestination(target3);
            if ((Vector3.Distance(transform.position, target3)) < 2 || timer > ventetid)
            {
                targetNummer = targetNummer + 1;
                timer = 0;
            }
        }
        else if (targetNummer == 4)
        {
            _agent.SetDestination(target4);
            if ((Vector3.Distance(transform.position, target4)) < 2 || timer > ventetid)
            {
                targetNummer = targetNummer + 1;
                timer = 0;
            }
        }
        else if (targetNummer == 5)
        {
            _agent.SetDestination(target5);
            if ((Vector3.Distance(transform.position, target5)) < 2 || timer > ventetid)
            {
                targetNummer = targetNummer + 1;
                timer = 0;
            }
        }
        else
        {
            phaseManager.phase = 1;
        }
        timer = timer+1*Time.deltaTime;
    }
}
