using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class potion : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI potionNumber;
    [HideInInspector] public int PotionNum = 0;
    void Update()
    {
        potionNumber.text = PotionNum.ToString();
    }

   
}
