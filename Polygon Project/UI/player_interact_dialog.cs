using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_interact_dialog : MonoBehaviour
{
    public GameObject player;
    public Collider triggCol;
    public GameObject dialogController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogController.gameObject.SetActive(true);
            dialogController.GetComponent<player_dialogTrigger>().triggerDialogue();
        }
    }
}
