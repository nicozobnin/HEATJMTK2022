using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public ArrayList resources = new();
    /* Order: Pickaxe, Axe, Sickle
     * Format: (Resource ID, quantity)
    {
        (0, 1),
        (0, 1),
        (0, 1)
    }*/
    public string name;
    public int hazard;
    public GameObject[] slots;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
        Debug.Log(resources[0]);
        Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
