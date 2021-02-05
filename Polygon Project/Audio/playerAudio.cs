using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudio : MonoBehaviour
{
    //AudioSource AudioSource;
    //public AudioClip tiengbuocchan;
    Animator playerAnim;
    private void Awake()
    {
        //AudioSource = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
    }
    void buocChan()
    {
        if(playerAnim.GetFloat("speedpercent")>0.1f && playerAnim.GetFloat("speedpercent")<0.6f)
        {
            Debug.Log("ham buoc chan dc goi");
            //AudioSource.PlayOneShot(tiengbuocchan, 0.7f);

            FindObjectOfType<AudioManager>().Play("tieng_buoc_chan");
        }
    }

    void chay()
    {
        if (playerAnim.GetFloat("speedpercent") >= 0.6f)
        {
            Debug.Log("ham chay dc goi");
            FindObjectOfType<AudioManager>().Play("tieng_chay");
        }
    }
}
