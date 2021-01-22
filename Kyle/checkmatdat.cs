using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkmatdat : MonoBehaviour
{
    public Transform gocray;
    public bool isGrounded;
    public float distance = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 dir = new Vector3(0f, -1f, 0f);

        if (Physics.Raycast(gocray.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Debug.Log("co tren mat dat: " + isGrounded);
        Debug.DrawLine(gocray.position,hit.point,Color.red);
    }
}
