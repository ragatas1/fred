using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisionCone2 : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    public float ventetid;
    public GameObject txt;
    public PhaseManager phaseManager;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    [HideInInspector] public bool ser;
    public float timer;
    public float chasetid;
    
    void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; ++i)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward,dirToTarget) <viewAngle/2)
            {
                float dstToTarget =Vector3.Distance(transform.position,target.position);

                if (!Physics.Raycast(transform.position,dirToTarget,dstToTarget,obstacleMask))
                {
                    ser = true;
                }
                else ser = false;
            }
        }
    }
    private void Update()
    {
        if (ser)
        {
            timer = timer + 1 * Time.deltaTime;
            if (timer > chasetid)
            {
                if (phaseManager.phase != 3)
                {
                    StartCoroutine(dod());
                }
            }
            else
            {
                phaseManager.phase = 2;
            }
        }
        else
        {
            timer = 0;
        }

    }
    public Vector3 DirFromAngle (float angleinDegrees)
    {
        return new Vector3 (Mathf.Sin(angleinDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleinDegrees*Mathf.Deg2Rad));
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindTargetsWithDelay(0.2f));
    }
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    IEnumerator dod()
    {
        txt.SetActive(true);
        phaseManager.phase = 3;
        yield return new WaitForSeconds(ventetid);
        txt.SetActive(false);
    }

}
