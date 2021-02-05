using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enable_chest_UI : MonoBehaviour
{
    Animator chestAnim;
    public GameObject chestUI;
    public GameObject player;
    float pickupTime = 1.5f;
    float timeHientai = 0f;
    bool chestEnable = false;
    public Image openProgress;
    public Collider triggCol;

    IEnumerator tangGold(int dur, int gold)
    {
        int goldDau = player.GetComponent<gold>().goldNum;
        int goldSau = goldDau + gold + 1;
        float lerp = 0f;
        while (lerp < dur)
        {
            player.GetComponent<gold>().goldNum = (int)Mathf.Lerp(goldDau,goldSau, lerp/dur);
            lerp += Time.deltaTime;
            yield return null;
        } 
    }

    void Start()
    {
        chestAnim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            chestUI.gameObject.SetActive(true);
            chestEnable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            chestUI.gameObject.SetActive(false);
            chestEnable = false;
        }
    }

    void batdauOpen()
    {
        timeHientai += Time.deltaTime;
        if (timeHientai >= pickupTime)
        {
            Debug.Log("da mo hom");
            StartCoroutine(tangGold(2,20));
            player.GetComponent<potion>().PotionNum += 2;
            chestAnim.enabled = true;
            triggCol.enabled = false;
            chestUI.gameObject.SetActive(false);
            GetComponent<enable_chest_UI>().enabled = false;
        }
    }

    void updateOpenProgress()
    {
        float phanTramTime = timeHientai / pickupTime;
        openProgress.fillAmount = phanTramTime;
    }

    void Update()
    {
        if (chestEnable)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("dang mo hom");
                batdauOpen();
            }
            else
            {
                timeHientai = 0f;
            }

            updateOpenProgress();
        }
    }
}
