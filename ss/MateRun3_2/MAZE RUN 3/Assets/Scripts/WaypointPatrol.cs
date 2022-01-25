using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Access to the NavMeshAgent class

// It should set the destination of the Nav Mesh Agent both when the Scene is first loaded and whenever
// the Ghost has reached its destination
public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);     //set the initial destination of the Nav Mesh Agent
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)     //Does Nav Mesh Agent has arrived at its destination?
        {                                                                       //if remaining distance to the destination is less than the stopping distance
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; //The remainder operator takes whatever is to its left and divides it 
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);  //by whatever is to its right, then returns the remainder    
        }
        
    }
}
