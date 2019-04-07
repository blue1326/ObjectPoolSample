using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCash
{

    private static MaterialCash _inst;

    private Material[] mats = new Material[10];

    private MaterialCash()
    {
    }

    ~MaterialCash()
    {
    }

    public static MaterialCash Inst
    {
        get
        {
            if (_inst == null)
            {
                
                _inst = new MaterialCash();
                _inst.Init();
            }
            return _inst;
        }
    }

    private void Init()
    {
        mats = Resources.LoadAll<Material>("Material/Sphere/");
    }

    public Material GetRandomMaterial()
    {
        return mats[Random.Range(0, mats.Length - 1)];
    }
}
