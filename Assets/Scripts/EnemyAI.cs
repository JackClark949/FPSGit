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
    float turnSpeed = 5f;

    //Enemystate
    bool isAggro = false;

    private void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(Target.position, transform.position);

        if (distanceToPlayer <= aggroRange)
        {
            isAggro = true;
          
        }

        if (isAggro)
        {
            EngagingPlayerWhenAggroed();
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    private void Chaseplayer()
    {
        
        
            nMA.SetDestination(Target.transform.position);
       
        

        
    }

    private void EngagingPlayerWhenAggroed()
        
    {
        RotateToFacePlayer();
        if (distanceToPlayer >= nMA.stoppingDistance)
        {
            Chaseplayer();
        }

        if (distanceToPlayer <= nMA.stoppingDistance)
        {
            Attackplayer();
        }

    }

    private void Attackplayer()
    {
        print("attacking");
    }

    void RotateToFacePlayer()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion myCurrentRotation = transform.rotation;
        Quaternion myDesiredRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        Quaternion.Lerp(myCurrentRotation, myDesiredRotation, Time.deltaTime * turnSpeed);

    }
}
