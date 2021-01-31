using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gold : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldNumber;
    public int goldNum = 20;

    void Update()
    {
        goldNumber.text = goldNum.ToString();
    }
}
