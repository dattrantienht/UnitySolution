using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    [SerializeField]
    KeyCode Krestart;
    void Update()
    {
        if (Input.GetKey(Krestart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
