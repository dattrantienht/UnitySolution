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
    CharacterController controller;

    public bool chemdc = true;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }
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
        bool chiendau = player.GetComponent<playercontroller>().rutkiem;
        if (Input.GetKeyDown(KeyCode.H) && (!chiendau))
        {
            StartCoroutine(tangMau(2, 25));
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

    IEnumerator tangMau(int dur, int mau)
    {
        int maxheal = mauToiDa - mauHienTai;
        mau = Mathf.Clamp(mau, 0, maxheal);
        int mauDau = mauHienTai;
        int mauSau = mauHienTai + mau +1;
        float lerp = 0f;
        while (lerp < dur)
        {
            mauHienTai = (int)Mathf.Lerp(mauDau, mauSau, lerp / dur);
            lerp += Time.deltaTime;
            yield return null;
        }
    }

    public virtual void Chet()
    {
        playerAnim.SetBool("dead",true);
        //controller.enabled = false;
        //GetComponent<dichuyen>().enabled = false;
    }
}
