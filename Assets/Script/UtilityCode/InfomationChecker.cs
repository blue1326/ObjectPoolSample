using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("Utilities/InfomationChecker")]
public class InfomationChecker : MonoBehaviour
{

    public Rect startRect = new Rect(10, 10, 75, 50);
    public bool updateColor = true; 
    public bool allowDrag = true;
    public float frequency = 0.5F; // The update frequency of the infomations
    private GUIStyle style;
    // Start is called before the first frame update
    [SerializeField]
    private Base_MonoBehaviour target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Info()
    {
        while(true)
        {
            

            yield return new WaitForSeconds(frequency);
        }
    }
}
