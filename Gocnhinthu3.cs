using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float tocDo = 6f;
    public float xoayMuotTime = 0.1f;
    float tocDoXoayMuot;
    void Update()
    {
        float chieungang = Input.GetAxisRaw("Horizontal");
        float chieudoc = Input.GetAxisRaw("Vertical");
        Vector3 huongdichuyen = new Vector3(chieungang,0f,chieudoc).normalized;

        if (huongdichuyen.magnitude >= 0.1f)
        {
            float gocxoay = Mathf.Atan2(huongdichuyen.x,huongdichuyen.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float goc = Mathf.SmoothDampAngle(transform.eulerAngles.y,gocxoay, ref tocDoXoayMuot, xoayMuotTime);
            transform.rotation = Quaternion.Euler(0f,goc,0f);

            Vector3 huong = Quaternion.Euler(0f, gocxoay, 0f) * Vector3.forward;
            controller.Move(huong.normalized * tocDo * Time.deltaTime);
        }

    }
}
