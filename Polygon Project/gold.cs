using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gold : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldNumber;
    [HideInInspector] public int goldNum = 0;
    void Update()
    {
        goldNumber.text = goldNum.ToString();
    }

   
}
