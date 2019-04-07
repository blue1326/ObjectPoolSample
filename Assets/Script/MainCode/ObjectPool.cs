using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]//단일 오브젝트 중복방지
public class ObjectPool : Base_MonoBehaviour
{
   //variables
    [Header("Default")]
    [SerializeField]
    private GameObject poolingObj = null;

    [SerializeField]
    [Tooltip("Set poolsize to max")]
    private bool isMaxPool = false;
    [SerializeField]
    [Range(10,1000)]
    [Tooltip("Set poolsize if unchecked isMaxPool")]
    private int iPoolSize;


    enum DATASET{ QUEUE,LIST }

    [Header("Extention")]
    [Tooltip("if you need optional technique")]
    [SerializeField]
    private DATASET dataset = DATASET.QUEUE;
    
    private Queue<GameObject> restObj_queue;
    private List<GameObject> restObj_list;



    private void Awake()
    {
        switch(dataset)
        {
            case DATASET.QUEUE:
                restObj_queue = new Queue<GameObject>();
                break;
            case DATASET.LIST:
                restObj_list = new List<GameObject>();
                break;
        }



        if (isMaxPool) iPoolSize = 1000;
        
        for(int i =0; i< iPoolSize;i++)
        {
            CreatePoolingObjects(i);
        }
    }

    private void CreatePoolingObjects(int _idx)
    {
        GameObject child = Instantiate(poolingObj,this.transform);
        child.SetActive(false);
        child.AddComponent<PoolingObjectControl>();
        PoolingObjectControl control = child.GetComponent<PoolingObjectControl>();
        control.holder = this.gameObject;
        control.pool = this;

        SetUpDataSet(child);

    }

    public void SetUpDataSet(GameObject _obj)
    {
        switch (dataset)
        {
            case DATASET.QUEUE:
                restObj_queue.Enqueue(_obj);
                break;
            case DATASET.LIST:
                restObj_list.Add(_obj);
                break;
        }
    }
    public GameObject AwakeGameObject()
    {
        GameObject obj = null;
        switch (dataset)
        {
            case DATASET.QUEUE:
                if (restObj_queue.Count != 0)
                {
                    obj = restObj_queue.Dequeue();
                    Info = $"{restObj_queue.Count}/{iPoolSize}";
                }
                break;
            case DATASET.LIST:
                if(restObj_list.Count != 0)
                {
                    obj = restObj_list[0];
                    restObj_list.RemoveAt(0);
                    Info = $"{restObj_list.Count}/{iPoolSize}";
                }
                break;
        }
        obj.SetActive(true);
        Debug.Log(Info);
        return obj;
    }

}
