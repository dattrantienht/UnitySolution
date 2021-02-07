using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_dialogTrigger : MonoBehaviour
{
    public player_loiThoai LoiThoai;
    public GameObject dialogZone;

    public void triggerDialogue()
    {
        dialogZone.GetComponent<player_DialogManager>().batDauHoiThoai(LoiThoai);
    }

}
