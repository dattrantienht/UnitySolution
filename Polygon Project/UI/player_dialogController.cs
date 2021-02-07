using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_dialogController : MonoBehaviour
{
    public GameObject dialogUI;
    public Collider dialogCol;
    public GameObject dialogZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogUI.gameObject.SetActive(true);
        }
    }
}
