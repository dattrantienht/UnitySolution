using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateThanhMau : MonoBehaviour
{
    //public Image HPbar;
    public int HP;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Update()
    {
        HP = GetComponent<HP>().mauHienTai;
        slider.value = HP / 100f;
        fill.color = gradient.Evaluate(slider.value);
        //HPbar.fillAmount = HP / 100f;
    }
}
