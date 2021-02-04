using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI NPCname;
    public TextMeshProUGUI khungThoai;
    public GameObject dialogueSystem;

    private Queue<string> loiThoai;
    void Start()
    {
        loiThoai = new Queue<string>();
    }

    public void batDauHoiThoai( loiThoai LoiThoai )
    {
        Debug.Log("bat dau noi chuyen voi" + LoiThoai.ten);

        NPCname.text = LoiThoai.ten;
        loiThoai.Clear();

        foreach (string cauthoai in LoiThoai.cacLoiThoai)
        {
            loiThoai.Enqueue(cauthoai);
        }

        hienThiCauTiepTheo();
    }

    public void hienThiCauTiepTheo()
    {
        if (loiThoai.Count == 0  )
        {
            endDialogue();
            return;
        }

        string sentence = loiThoai.Dequeue();
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator typeSentence(string sentence)
    {
        khungThoai.text = "";
        foreach (char kitu in sentence.ToCharArray())
        {
            khungThoai.text += kitu;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void endDialogue()
    {
        Debug.Log("ket thuc cuoc hoi thoai");
        dialogueSystem.gameObject.SetActive(false);
    }
}
