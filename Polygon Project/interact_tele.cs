using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class interact_tele : MonoBehaviour
{
    
    public GameObject interactUI;
    public GameObject player;
    float interactTime = 1.5f;
    float timeHientai = 0f;
    bool inZone = false;
    public Image interactProgress;
    public Collider triggCol;
    public string sceneName;

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
        Debug.Log("da tuong tac");
        int gold = player.GetComponent<gold>().goldNum;
        int HP = player.GetComponent<HP>().mauHienTai;
        int potion = player.GetComponent<potion>().PotionNum;
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("HP", HP);
        PlayerPrefs.SetInt("potion",potion);

        Debug.Log("gold dc luu:" + gold);
        Debug.Log("HP dc luu:" + HP);
        SceneManager.LoadScene(sceneName);
    }

    void batdauTuongtac()
    {
        timeHientai += Time.deltaTime;
        if (timeHientai >= interactTime)
        {
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
