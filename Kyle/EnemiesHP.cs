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
    public Collider weaponcol;
    Animator animator;
    public Animator playerAnim;
    bool chemdcE = true;

    IEnumerator Ebattu()
    {
        yield return new WaitForSeconds(1f);
        chemdcE = true;
    }
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
        if (other.tag == "My Weapon" && chemdcE && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            nhanSatThuong(20);
            animator.SetTrigger("gethit");
            chemdcE = false;
            StartCoroutine(Ebattu());
        }
    }

    public void nhanSatThuong(int satThuong)
    {
        satThuong -= giap.getValue();
        satThuong = Mathf.Clamp(satThuong, 0, int.MaxValue);
        mauHienTai -= satThuong;

        if (mauHienTai <= 0)
        {
            Chet();   
        }
    }

    public virtual void Chet()
    {
        animator.SetBool("dead",true);
        enemycollider.enabled = false;
        weaponcol.enabled = false;
        enemy.enabled = false;
        GetComponent <enemycontroller> ().enabled = false;
        StartCoroutine(tatAnim());
    }
}
