using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public ArrayList resources = new();
    /* Order: Pickaxe, Axe, Sickle
     * Format: (Resource ID, quantity)
    {
        (0, 1),
        (0, 1),
        (0, 1)
    }*/
    public string nodeName;
    public int hazard;
    public GameObject[] slots;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
        Debug.Log(resources);
        Debug.Log(nodeName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public ArrayList getResources()
    {
        return resources;
    }
}
