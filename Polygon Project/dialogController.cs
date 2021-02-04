using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogController : MonoBehaviour
{
    public GameObject dialogUI;
    public Collider dialogCol;
    public GameObject dialogZone;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogUI.gameObject.SetActive(true);   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dialogUI.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogZone.GetComponent<DialogManager>().hienThiCauTiepTheo(); 
        }
    }
}
