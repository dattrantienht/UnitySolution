using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HPsystem
{
    [SerializeField]
    private int giaTriGoc;

    //private List<int> mods = new List<int>();
    public int getValue()
    {
        return giaTriGoc;
    }

    //public void addmods(int mod)
    //{
    //    if (mod != 0)
    //        mods.Add(mod);
    //}

    //public void removemods(int mod)
    //{
    //    if (mod != 0)
    //        mods.Remove(mod);
    //}
}

