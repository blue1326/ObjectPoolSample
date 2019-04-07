using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    ObjectPool pool = null;
    [SerializeField]
    GameObject RespawnRange = null;
    Vector3 RangePivot;

    [SerializeField]
    bool isMoveToWorld = false;
    private void Awake()
    {
        //Vector3 tmp = new Vector3();
        
        //Debug.Log($"count #: X : {tmp.x} Y : {tmp.y} Z : {tmp.z}");
        Mesh mesh = RespawnRange.GetComponent<MeshFilter>().mesh;
        Matrix4x4 world = RespawnRange.transform.localToWorldMatrix;

        Vector3 lPosition = mesh.vertices[0];
        lPosition.y = 0;
        RangePivot = world.MultiplyPoint(lPosition);

//        Debug.Log(RangePivot.ToString());
  

        pool = GetComponentInChildren<ObjectPool>();
    }
    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        while(true)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject tmpobj = pool.AwakeGameObject();
                Vector3 randomvec = new Vector3(Random.Range(-RangePivot.x, RangePivot.x), RangePivot.y, Random.Range(-RangePivot.z, RangePivot.z));
                tmpobj.transform.position = randomvec;
                if(isMoveToWorld)
                {
                    tmpobj.transform.parent = null;
                }
            }
            yield return new WaitForSeconds(0.2f);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
