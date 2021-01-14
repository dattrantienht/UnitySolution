//jump mot cach kho hieu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_and_jump : MonoBehaviour
{
    public GameObject nhanvat;
    public CharacterController controller;
    public float lucHut = -9.8f; //phai la so am
    Vector3 playerVelocity;

    public float lucNhay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool dangdung = nhanvat.GetComponent<checkmatdat>().isGrounded;

        if (dangdung && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && dangdung)
        {
            playerVelocity.y += Mathf.Sqrt(lucNhay * -3.0f * lucHut);
        }

        playerVelocity.y += lucHut * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
