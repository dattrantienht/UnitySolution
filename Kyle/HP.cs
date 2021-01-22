using UnityEngine;

public class HP : MonoBehaviour
{
    public int mauToiDa = 100;
    public int mauHienTai { get; private set; }

    public HPsystem giap;
    public HPsystem satThuong;

    private void Awake()
    {
        mauHienTai = mauToiDa;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            nhanSatThuong(10);
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
    }
}
