using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player_DialogManager : MonoBehaviour
{
    public TextMeshProUGUI cauThoai;
    public GameObject dialogueSystem;
    public GameObject thoiGianSong;
    public void batDauHoiThoai( player_loiThoai cauNoi )
    {
        string sentence = cauNoi.LoiThoai;
        Debug.Log("player: " + sentence);
        StartCoroutine(typeSentence(sentence));
    }
    IEnumerator typeSentence(string sentence)
    {
        cauThoai.text = "";
        foreach (char kitu in sentence.ToCharArray())
        {
            cauThoai.text += kitu;
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log("co chay ham typeSentence");
        thoiGianSong.gameObject.SetActive(true);
        dialogueSystem.gameObject.SetActive(false);
    }
}
