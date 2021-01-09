using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieukhien : MonoBehaviour
{
    [SerializeField]
    Vector3 V3;
    [SerializeField]
    KeyCode tien;
    [SerializeField]
    KeyCode lui;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(tien))
            GetComponent<Rigidbody>().velocity += V3;
        if (Input.GetKey(lui))
            GetComponent<Rigidbody>().velocity -= V3;
    }
}
