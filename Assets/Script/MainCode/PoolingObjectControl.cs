using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObjectControl : MonoBehaviour
{
    private GameObject Holder = null;
    public GameObject holder { set => Holder = value; }
    private ObjectPool Pool = null;
    public ObjectPool pool { set => Pool = value; }
    private void OnDisable()
    {
        if (Holder && this.transform.parent != Holder)
        {
            //to avoid exceptions set delay 0.1f
            Invoke("ReturnHolder", 0.1f);   
        }
        if (Pool)
            Pool.SetUpDataSet(this.gameObject);
    }
    private void ReturnHolder()
    {
        this.transform.parent = Holder.transform;
    }
}

