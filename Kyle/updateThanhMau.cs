using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateThanhMau : MonoBehaviour
{
    public Image HPbar;
    public int HP;

    private void Update()
    {
        HP = GetComponent<HP>().mauHienTai;
        HPbar.fillAmount = HP / 100f;
    }
}
