using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playermotor))]
public class playercontroler : MonoBehaviour
{
    
    public LayerMask movementmask;
    Camera cam;
    playermotor motor;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<playermotor>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementmask))
            {
                motor.movetopoint(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementmask))
            {
                motor.movetopoint(hit.point);
            }
        }
    }
}
