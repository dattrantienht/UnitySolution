using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interact_dialog : MonoBehaviour
{
    
    public GameObject interactUI;
    public GameObject player;
    float interactTime = 1.5f;
    float timeHientai = 0f;
    bool inZone = false;
    public Image interactProgress;
    public Collider triggCol;
    public GameObject dialogController;

    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interactUI.gameObject.SetActive(true);
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactUI.gameObject.SetActive(false);
            inZone = false;
        }
    }

    void scriptTuongTac()
    {
        //viet script tuong tac vao day
        dialogController.gameObject.SetActive(true);
        dialogController.GetComponent<dialogTrigger>().triggerDialogue();
    }

    void batdauTuongtac()
    {
        timeHientai += Time.deltaTime;
        if (timeHientai >= interactTime)
        {
            Debug.Log("da tuong tac");
            scriptTuongTac();
            triggCol.enabled = false; 
            interactUI.gameObject.SetActive(false);
        }
    }

    void updateOpenProgress()
    {
        float phanTramTime = timeHientai / interactTime;
        interactProgress.fillAmount = phanTramTime;
    }

    void Update()
    {
        if (inZone)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("dang tuong tac");
                batdauTuongtac();
            }
            else
            {
                timeHientai = 0f;
            }

            updateOpenProgress();
        }
    }
}
