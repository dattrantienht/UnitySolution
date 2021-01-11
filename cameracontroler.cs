using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroler : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float zoomspeed = 4f;
    public float minzoom = 1.9f;
    public float maxzoom = 6f;
    public float yawSpeed = 100f;
    
    
    public float pitch = 2f;
    private float currentZoom = 5f;
    private float currentYaw = 0f;
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel")*zoomspeed;
        currentZoom = Mathf.Clamp(currentZoom,minzoom,maxzoom);

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
        
    }
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position,Vector3.up,currentYaw);
    }
}
