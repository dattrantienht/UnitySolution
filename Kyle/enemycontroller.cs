using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller : MonoBehaviour
{
    public float tamNhin = 6f;
    Transform target;
    NavMeshAgent enemy;
    Animator enemyAnim;
    void Start()
    {
        target = playermanager.instance.player.transform;
        enemy = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
    }
    void Update()
    {
        float khoangCach = Vector3.Distance(target.position,transform.position);
        if (khoangCach <= tamNhin)
        {
            enemy.SetDestination(target.position);
            if (khoangCach <= enemy.stoppingDistance + 1f)
            {
                enemyAnim.SetTrigger("attack");
                facetarget();
            }
            else
            {
                enemyAnim.SetBool("tancong", false);
                enemyAnim.SetFloat("enemyBlend", 1f, 0.1f, Time.deltaTime);
            }
        }
        else
        {
            enemyAnim.SetFloat("enemyBlend", 0f, 0.1f, Time.deltaTime);
        }
    }

    void facetarget()
    {
        Vector3 huongNhin = (target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(huongNhin.x, 0, huongNhin.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, 5f*Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,tamNhin);
    }
}
