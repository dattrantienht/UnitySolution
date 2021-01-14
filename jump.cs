//jump mot cach de hieu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public GameObject raycheck;
    public CharacterController controller;
    public float lucHut = 9.8f;
    public float lucNhay = 3f;
    Vector3 playerVelocity;

    // Update is called once per frame
    void Update()
    {
        bool dangdung = raycheck.GetComponent<checkmatdat>().isGrounded;

        if (dangdung)
        {
            playerVelocity.y = -lucHut * Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y = lucNhay;
            }
        }
        else
        {
            playerVelocity.y -= lucHut * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log("vector nhay la: " + playerVelocity );

    }
}
