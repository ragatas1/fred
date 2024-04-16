using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : MonoBehaviour
{
    public List<Transform> waypoints;
    public Transform currentTarget;
    private int _index = 1;
    public float upperRandom;
    public float lowerRandom;

    private NavMeshAgent _agent;
    private Animator _animator;

    private bool _inReverse = false;
    private bool _atEnd = false;
    private bool _moving = true;
    PhaseManager phaseManager;


    //https://bergstrand-niklas.medium.com/simple-waypoint-system-in-unity-f3ef3665d636
    //linken jeg brukte^^

    void Start()
    {
        phaseManager = GetComponent<PhaseManager>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        /*
        if (_agent != null)
            Debug.LogError("NavMeshAgent missing");

        if (_animator != null)
            Debug.LogError("Animator Missing");
        */
        //If there are waypoints and the first waypoint is not null
        if (waypoints.Count > 0 && waypoints[0] != null)
        {
            //Set first target
            currentTarget = waypoints[_index];

            //Start moving the ai(agent) towards the first target
            _agent.SetDestination(currentTarget.position);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(MoveToNextWaypoint());
    }

    IEnumerator MoveToNextWaypoint()
    { 
        if (!_inReverse)
        {
            _index++;
        }

        //If not at the last waypoint and not going in reverse
        if (_index < waypoints.Count && !_inReverse)
        {
            //Pause a random amount of time before going to the first point
            if (_index == 1)
                yield return new WaitForSeconds(Random.Range(lowerRandom, upperRandom));

            currentTarget = waypoints[_index];
        }
        else
        {
            //If at the last point pause for a random amount of time
            if (!_atEnd)
            {
                _atEnd = true;
                yield return new WaitForSeconds(Random.Range(3f, 6f));
            }

            _index--;
            _inReverse = true;


            //if next waypoint is the first waypoint reset _inReverse and _atEnd
            if (_index == 0)
            {
                _inReverse = false;
                _atEnd = false;
            }

            currentTarget = waypoints[_index];
        }

        //Move AI (agent) to next waypoint
        _agent.SetDestination(currentTarget.position);
        _moving = true;
    }

    void Update()
    {
        //get current speed percent of AI(agent) and set the speed parameter of the animator
        float v = _agent.velocity.magnitude / _agent.speed;
        float speedPercent = v;
        //_animator.SetFloat("Speed", speedPercent);
            if (currentTarget != null)
            {
                //Check if the AI(agent) has arrived the target position
                if ((Vector3.Distance(transform.position, currentTarget.position) <= 2f) && _moving)
                {
                    //Set moving to false to prevent this if statment from constantly running while at target position
                    _moving = false;
                    StartCoroutine("MoveToNextWaypoint");
                }
            }
        
        
    }
}
