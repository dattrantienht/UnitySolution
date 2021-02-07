using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav_pet : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
        if (agent.velocity != Vector3.zero && agent.remainingDistance > 0.2f)
        {
            animator.SetBool("walking", true);
            if (agent.remainingDistance > 3f)
            {
                animator.SetBool("runing", true);
                agent.speed = 8f;
            }
            else
            {
                animator.SetBool("runing", false);
                agent.speed = 3f;
            }
        }
        else
            animator.SetBool("walking", false);
        //Debug.Log("remaining Distance:" + agent.remainingDistance);
    }
}
