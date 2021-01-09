using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyPos : MonoBehaviour
{
    [SerializeField]
    Transform tranTarget;
    void Update()
    {
        transform.position = tranTarget.position; 
    }
}
