using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nhacNen : MonoBehaviour
{
    public static nhacNen instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //DontDestroyOnLoad(this.gameObject);
    }
}
