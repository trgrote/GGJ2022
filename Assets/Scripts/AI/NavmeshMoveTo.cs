using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavmeshMoveTo : MonoBehaviour
{
    [SerializeField] Transform _goal;
    NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        // _agent.destination = _goal.position; 
    }

    [NaughtyAttributes.Button]
    void GoToRandomPosition()
    {
        NavMeshHit navMeshHit;
        bool foundPosition = NavMesh.SamplePosition(
            transform.position + Random.insideUnitSphere * 20f,
            out navMeshHit,
            20f,
            NavMesh.AllAreas
        );

        _agent.SetDestination(navMeshHit.position);
    }
}
