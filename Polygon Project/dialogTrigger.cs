using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTrigger : MonoBehaviour
{
    public loiThoai LoiThoai;
    public GameObject dialogZone;

    public void triggerDialogue()
    {
        dialogZone.GetComponent<DialogManager>().batDauHoiThoai(LoiThoai);
    }

}
