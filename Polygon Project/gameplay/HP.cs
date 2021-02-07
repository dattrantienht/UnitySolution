using System.Collections;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int mauToiDa = 100;
    public int mauHienTai { get; set; }

    public GameObject player;
    public GameObject dieUI;
    public GameObject gameUI;
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

    IEnumerator showDIE()
    {
        yield return new WaitForSeconds(1.5f);
        dieUI.SetActive(true);
        gameUI.SetActive(false);
    }

    private void Awake()
    {
        mauHienTai = mauToiDa;
    }

    public void Update()
    {
        bool chiendau = player.GetComponent<playercontroller>().rutkiem;
        if (Input.GetKeyDown(KeyCode.H) && (!chiendau) && player.GetComponent<potion>().PotionNum > 0)
        {
            playerAnim.SetTrigger("uong");
            StartCoroutine(tangMau(2, 25));
            uongThuoc();
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

    public void uongThuoc()
    {
        player.GetComponent<potion>().PotionNum = Mathf.Clamp(player.GetComponent<potion>().PotionNum,0,30); 
        player.GetComponent<potion>().PotionNum -= 1;
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
        StartCoroutine(showDIE());
        //controller.enabled = false;
        //GetComponent<dichuyen>().enabled = false;
    }
}
