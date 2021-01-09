using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartoncoll : MonoBehaviour
{
    [SerializeField]
    string collTag;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag==collTag)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
