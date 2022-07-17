using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    //this method implies no Slots spawns with the Node
    //but rather X ammount will be create on start/Unlock
    public int MAX_SLOTS = 6;
    public int slotcounter =-1;
    public int sloInitialAmmount = 3;



    public List<GameObject> SlotList = new List<GameObject>();

    public List<List<int>> resources = new() 
    { 
        new List<int> { 0, 1 },
        new List<int> { 1, 1 },
        new List<int> { 2, 1 }
    };


    /* Order: Pickaxe, Axe, Sickle
     * Format: (Resource ID, quantity)
     * */
    //Test
    public bool IsTest;
    //end of test
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

    }

    // Update is called once per frame
    void Update()
    {
        if(IsTest)
        {

        }
    }
    

    //Returns [Resource ID, Quantity]
    public List<int> ReturnResource(int type)
    {
        return resources[type];
    }


    public List<int> RollBlueprint()
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
                return new List<int> { (int)i[0], (int)i[1] };
            }
        }
        return null;
    }
}
