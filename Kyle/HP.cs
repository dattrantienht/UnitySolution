using System.Collections;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int mauToiDa = 100;
    public int mauHienTai { get; private set; }

    public HPsystem giap;
    public HPsystem satThuong;
    public Animator playerAnim;

    public bool chemdc = true;

    IEnumerator battu()
    {
        yield return new WaitForSeconds(1f);
        chemdc = true;
    }

    private void Awake()
    {
        mauHienTai = mauToiDa;
    }

    public void Update()
    {
        //Debug.Log("co chem dc ko: " + chemdc);
    }

    private void OnTriggerEnter(Collider vukhi)
    {

        if (vukhi.tag == "EWeapon" && chemdc)
        {
            nhanSatThuong(5);
            playerAnim.SetTrigger("Pgethit");
            chemdc = false;
            StartCoroutine(battu());
        }
    }
    public void nhanSatThuong (int satThuong)
    {
        satThuong -= giap.getValue();
        satThuong = Mathf.Clamp(satThuong, 0, int.MaxValue);
        mauHienTai -= satThuong;
        Debug.Log(transform.name + "nhan " + satThuong + " sat thuong.");

        if (mauHienTai <= 0)
        {
            Chet();
        }
    }

    public virtual void Chet()
    {
        Debug.Log(transform.name + " da chet.");
        playerAnim.SetBool("dead",true);
    }
}
