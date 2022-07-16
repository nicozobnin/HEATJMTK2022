using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public List<List<int>> resources = new() 
    { 
        new List<int> { 0, 1 },
        new List<int> { 1, 1 },
        new List<int> { 2, 1 }
    };
    /* Order: Pickaxe, Axe, Sickle
     * Format: (Resource ID, quantity)
     * */

    public string nodeName;
    public int hazard;
    public GameObject[] slots;
    public ArrayList blueprintChances = new()
    {
        //(Face ID, Tier, Chance (float))
        (0, 0, 0.3f),
        (1, 0, 0.25f),
        (1, 1, 0.05f),
        (2, 0, 0.2f),
        (3, 0, 0.2f),
        (4, 0, 0.1f),
        (5, 0, 0.1f)
    };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
        Debug.Log(ReturnResource(0)[1]);
        Debug.Log(blueprintChances);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Returns [Resource ID, Quantity]
    public List<int> ReturnResource(int type)
    {
        return resources[type];
    }
}
