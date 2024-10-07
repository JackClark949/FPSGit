using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform Target;
    NavMeshAgent nMA;

    [SerializeField] float aggroRange = 5f;
    float distanceToPlayer;

    private void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(Target.position, transform.position);
        if(distanceToPlayer <= aggroRange)
        {
            nMA.SetDestination(Target.transform.position);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
