using System.Collections;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int mauToiDa = 100;
    public int mauHienTai { get; private set; }

    public GameObject player;
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
        bool chiendau = player.GetComponent<dichuyen>().rutkiem;
        if (Input.GetKeyDown(KeyCode.H) && (!chiendau))
        {
            healing(25);
            Debug.Log("uong binh mau");
        }
    }

    private void OnTriggerEnter(Collider vukhi)
    {

        if (vukhi.tag == "EWeapon" && chemdc)
        {
            if (playerAnim.GetBool("boolBlock"))
            {
                playerAnim.SetTrigger("Bgethit");
            }
            else
            {
                nhanSatThuong(10);
                playerAnim.SetTrigger("Pgethit"); 
            }
            chemdc = false;
            StartCoroutine(battu());
        }
    }
    public void nhanSatThuong (int satThuong)
    {
        satThuong -= giap.getValue();
        satThuong = Mathf.Clamp(satThuong, 0, int.MaxValue);
        mauHienTai -= satThuong;

        if (mauHienTai <= 0)
        {
            Chet();
        }
    }

    public void healing(int heal)
    {
        int maxheal = mauToiDa - mauHienTai;
        heal = Mathf.Clamp(heal, 0, maxheal);
        mauHienTai += heal;
    }

    public virtual void Chet()
    {
        playerAnim.SetBool("dead",true);
    }
}
