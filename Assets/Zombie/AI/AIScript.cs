using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

    // Start is called before the first frame update
    public int Attack_range;
    public int Chase_range;
    public int MoveSpeed;
    public int RotSpeed;
    public float Destination;
    public List<Transform> patrolMarkers;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public float viewRadius;
    public float viewAngle;
    public List<Transform> visibleTargets = new List<Transform>();
    Transform PatrolTarget;
    void Start()
    {
        Destination = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolMarkers.Count != 0)
        {
            //if (Destination == 1f)
            //    PatrolTarget = pos1;
            //else if (Destination == 2f)
            //    PatrolTarget = pos2;
            //else if (Destination == 3f)
            //    PatrolTarget = pos3;
            //else if (Destination == 4f)
            //    PatrolTarget = pos4;
        }
        else {
            PatrolTarget = transform;
        }


        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        //Debug.Log(targetsInViewRadius.Length);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }


        float Distance = (PatrolTarget.position - transform.position).magnitude;

        //Transform EnemyCube = FindClosestEnemy().transform;

        if (visibleTargets.Count == 0)
        {
        }
        else
        {
            Transform EnemyCube = visibleTargets[0];
            Vector3 targetDir = EnemyCube.position - transform.position;
            float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));
            //if (angleToPlayer >= -90 && angleToPlayer <= 90) {
            //    Debug.Log("PatrolTarget in sight!");
            //} // 180‹ FOV
                

            float DistanceEnemy = (EnemyCube.transform.position - transform.position).magnitude;

            if (Chase_range >= DistanceEnemy)
            {
                if (DistanceEnemy > Attack_range)
                {
                    Vector3 Direction = EnemyCube.position - transform.position;
                    Direction.y = 0;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), RotSpeed * Time.deltaTime);
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                    transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
                }
            }
            else if (Distance >= 1f)
            {
                Vector3 Direction = PatrolTarget.position - transform.position;
                Direction.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), RotSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }
            else
            {
                Destination++;
                if (Destination >= 5f)
                    Destination -= 4f;
            }
        }




        //Transform PatrolTarget = FindClosestEnemy().transform;
        //float Distance = (PatrolTarget.transform.position - transform.position).magnitude;

        //if (Chase_range >= Distance)
        //{
        //    if (Distance > Attack_range)
        //    {
        //        Vector3 Direction = PatrolTarget.position - transform.position;
        //        Direction.y = 0;
        //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), RotSpeed * Time.deltaTime);
        //        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        //        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        //    }
        //}

    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemy;
        enemy = GameObject.FindGameObjectsWithTag("EnemyCube");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject objekEnemy in enemy)
        {
            Vector3 diff = objekEnemy.transform.position - position;
            float curDistance = diff.magnitude;
            if (curDistance < distance)
            {
                closest = objekEnemy;
                distance = curDistance;
            }
        }
        return closest;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Attack_range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Chase_range);
    }
}
