using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        this.GetComponent<MeshRenderer>().material = MaterialCash.Inst.GetRandomMaterial();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            this.gameObject.SetActive(false);
        }
    }
}
