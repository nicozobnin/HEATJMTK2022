using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    private ArrayList resources;
    // Start is called before the first frame update
    void Start()
    {
        resources = this.GetComponentInParent<NodeController>().resources;
        Debug.Log(resources);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
