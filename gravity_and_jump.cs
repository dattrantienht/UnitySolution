//jump mot cach kho hieu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_and_jump : MonoBehaviour
{
    public GameObject raycheck;
    public CharacterController controller;
    public Animator animator;
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
        bool dangdung = raycheck.GetComponent<checkmatdat>().isGrounded;
        //bool dangdung = controller.isGrounded;
        if (dangdung && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && dangdung)
        {
            playerVelocity.y += Mathf.Sqrt(lucNhay * -4.0f * lucHut);
            animator.SetTrigger("jump");
        }

        playerVelocity.y += lucHut * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
