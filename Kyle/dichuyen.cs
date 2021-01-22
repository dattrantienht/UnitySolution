using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public Transform cam;
    float tocDo;
    public float tocdodi = 3f;
    public float tocdochay = 8f;
    public float xoayMuotTime = 0.1f;
    float tocDoXoayMuot;
    bool rutkiem = false;
    void Update()
    {
        if (
            animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree unarmed") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Blend Tree armed")  ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("roll") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Roll_unarmed")
           )
        {


            float chieungang = Input.GetAxisRaw("Horizontal");
            float chieudoc = Input.GetAxisRaw("Vertical");
            Vector3 huongdichuyen = new Vector3(chieungang, 0f, chieudoc).normalized;

            if (huongdichuyen.magnitude >= 0.1f)
            {
                float gocxoay = Mathf.Atan2(huongdichuyen.x, huongdichuyen.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float goc = Mathf.SmoothDampAngle(transform.eulerAngles.y, gocxoay, ref tocDoXoayMuot, xoayMuotTime);
                transform.rotation = Quaternion.Euler(0f, goc, 0f);

                Vector3 huong = Quaternion.Euler(0f, gocxoay, 0f) * Vector3.forward;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    tocDo = tocdochay;
                    animator.SetFloat("speedpercent", 1f, xoayMuotTime, Time.deltaTime);
                }
                else
                {
                    tocDo = tocdodi;
                    animator.SetFloat("speedpercent", .5f, xoayMuotTime, Time.deltaTime);
                }
                controller.Move(huong.normalized * tocDo * Time.deltaTime);
            }
            else
            {
                animator.SetFloat("speedpercent", 0f, xoayMuotTime, Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                if (!rutkiem)
                    rutkiem = true;
                else
                    rutkiem = false;
                animator.SetTrigger("rutkiem");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("attack", true);
            }

        }
    }

}
