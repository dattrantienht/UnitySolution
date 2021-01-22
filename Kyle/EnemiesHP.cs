using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesHP : MonoBehaviour
{
    public int mauToiDa = 90;
    public int mauHienTai { get; private set; }

    public HPsystem giap;
    public HPsystem satThuong;
    NavMeshAgent enemy;
    Collider enemycollider;
    Animator animator;
    public Animator playerAnim;

    IEnumerator tatAnim()
    {
        yield return new WaitForSeconds(2f);
        animator.enabled = false;
    }
    public void Start()
    {
        animator = GetComponent<Animator>();
        enemycollider = GetComponent<Collider>();
        enemy = GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        mauHienTai = mauToiDa;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "My Weapon")
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hit1") && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                nhanSatThuong(30);
                animator.SetTrigger("gethit");
            }
    }

    private void Update()
    {

    }
    public void nhanSatThuong(int satThuong)
    {
        satThuong -= giap.getValue();
        satThuong = Mathf.Clamp(satThuong, 0, int.MaxValue);
        mauHienTai -= satThuong;
        Debug.Log(transform.name + " nhan " + satThuong + " sat thuong.");

        if (mauHienTai <= 0)
        {
            Chet();   
        }
    }

    public virtual void Chet()
    {
        animator.SetBool("dead",true);
        Debug.Log(transform.name + " da chet.");
        enemycollider.enabled = false;
        enemy.enabled = false;
        GetComponent <enemycontroller> ().enabled = false;
        StartCoroutine(tatAnim());
    }
}
