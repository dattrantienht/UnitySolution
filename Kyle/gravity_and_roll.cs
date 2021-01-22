using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_and_roll : MonoBehaviour
{
    public GameObject raycheck;
    public CharacterController controller;
    public Animator animator;
    public Transform player;
    public float lucHut = -9.8f;
    Vector3 playerVelocity;

    public float lucNhay = 1.0f;
    float dashDistance = 3.5f;
    float dashSpeed = 6.0f;
    Vector3 startPosition;
    IEnumerator ControllerDash()
    {
        startPosition = player.position;
        while (dashDistance > Vector3.Distance(startPosition, transform.position))
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        bool dangdung = raycheck.GetComponent<checkmatdat>().isGrounded;
        if (dangdung && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ControllerDash());
            animator.SetTrigger("jump");
        }

        playerVelocity.y += lucHut * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
