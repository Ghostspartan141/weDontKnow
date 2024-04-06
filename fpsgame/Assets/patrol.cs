using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    public List<Transform> waypoint;
    NavMeshAgent navMeshAgent;
    public int currentWayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        walking();
    }

    private void walking()
    {
        if(waypoint.Count==0)
        {
            return;
        }
        float DistancetoWaypoint = Vector3.Distance(waypoint[currentWayPointIndex].position, transform.position);

        if(DistancetoWaypoint<=1)
        {
            currentWayPointIndex=(currentWayPointIndex+1)%waypoint.Count;
        }
        navMeshAgent.SetDestination(waypoint[currentWayPointIndex].position);
    }
}
