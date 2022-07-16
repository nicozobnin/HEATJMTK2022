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
    public List<ArrayList> blueprintChances = new()
    {
        //(Face ID, Tier, Chance (float))
        new ArrayList { 0, 0, 0.2f },
        new ArrayList { 1, 0, 0.15f },
        new ArrayList { 1, 1, 0.05f },
        new ArrayList { 2, 0, 0.2f },
        new ArrayList { 3, 0, 0.2f },
        new ArrayList { 4, 0, 0.1f },
        new ArrayList { 5, 0, 0.1f }
    };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hi");
        //Debug.Log(ReturnResource(0)[1]);
        //Debug.Log(blueprintChances);
        var a = RollBlueprint();
        Debug.Log(a[0]);
        Debug.Log(a[1]);
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

    public ArrayList RollBlueprint()
    {
        float totalWeight = 0.0f;
        foreach(ArrayList i in blueprintChances)
        {
            totalWeight += (float)i[2];
        }
        //Debug.Log(totalWeight);
        ;
        float itemWeightIndex = Random.Range(0.0f, totalWeight);
        float currentIndexWeight = 0.0f;
        foreach (ArrayList i in blueprintChances)
        {
            currentIndexWeight += (float)i[2];
            if (currentIndexWeight >= itemWeightIndex)
            {
                return new ArrayList { (int)i[0], (int)i[1] };
            }
        }


        return null;
    }
}
