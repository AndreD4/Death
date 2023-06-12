using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

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
      FaceTarget();
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
      GetComponent<Animator>().SetBool("attack", false);
      GetComponent<Animator>().SetTrigger("move");
      navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
  
    }

    private void FaceTarget()
    {
      Vector3 direction = (target.position - transform.position).normalized;
      Quaternion lookRotaion = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
      transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected() 
    {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
