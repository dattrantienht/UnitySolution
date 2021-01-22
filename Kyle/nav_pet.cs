using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav_pet : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if (agent.velocity != Vector3.zero && agent.remainingDistance > 0.15f)
        {
            animator.SetBool("walking", true);
            if (agent.remainingDistance > 5f)
            {
                animator.SetBool("runing", true);
                agent.speed = 4f;
            }
            else
            { 
                animator.SetBool("runing", false);
                agent.speed = 2f;
            }
        }
        else
            animator.SetBool("walking", false);
        //Debug.Log("remaining Distance:" + agent.remainingDistance);
    }
}
