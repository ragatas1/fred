using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VisionCone2 : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

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
                    Debug.Log("sett");
                }
            }
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

}
