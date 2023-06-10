using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        SetDestionation();
    }

    void SetDestionation()
    {
      distanceToTarget = Vector3.Distance(target.position, transform.position);
      if(isProvoked)
      {
        EngagedTarget();
      }
      else if(distanceToTarget <= chaseRange)
      {
        isProvoked = true;

        
      }    
    }

    private void EngagedTarget()
    {
      if(distanceToTarget >= navMeshAgent.stoppingDistance)
      {
        ChaseTarget();
      }
      if (distanceToTarget <= navMeshAgent.stoppingDistance)
      {
        AttackTarget();
      }
    }

    private void ChaseTarget()
    {
      GetComponent<Animator>().SetTrigger("move");
      navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log(name + "has got yah" + target.name);
    }

    void OnDrawGizmosSelected() 
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
