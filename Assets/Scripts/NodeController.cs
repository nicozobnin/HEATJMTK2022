using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    //this method implies no Slots spawns with the Node
    //but rather X ammount will be create on start/Unlock

    //All 6 slots are initialized on start
    //but those not active are turn off

    public int MAX_SLOTS = 6;
    public int slotcounter =-1;
    public int slotsInitialAmmount = 3;



    public List<GameObject> SlotList = new List<GameObject>();
    public List<SlotController> SlotListReference = new List<SlotController>(); //public for testing porpouses


    //unlock system
    public bool IsOn = false;
    public List<List<int>> unlockCost = new()
    {
        new List<int> { 0, 1 },
        new List<int> { 1, 1 },
        new List<int> { 2, 1 }
    };

    //can be upgraded to a list to differenciate betweeen different resources
    public int resourceMultiplier=1;
    public bool IsRolling = false;


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
        //Debug.Log(GetSlotDice(0));
        Debug.Log("Node starting");
        getSlotsReference();
        InitializeSlots();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTest)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RollDice();
            }
        }
    }
    void InitializeSlots()
    {
        if(SlotList.Count<slotcounter || slotcounter> MAX_SLOTS)
        {
            Debug.Log("SlotInitialization went wrong, counter is bigger than max ammount");
        }
        slotcounter = slotsInitialAmmount;
        for (int  i = 0; i< slotcounter; i++)
        {
            Debug.Log("activating slot");
            SlotListReference[i].setStatus(true);
        }
    }
    public void setStatus(bool onoff)
    {
        IsOn = onoff;
    }
    public bool CheckStatus()
    {
        if (IsOn)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            Debug.Log("set colore green");
            return true;
        }
        Debug.Log("set colore red");
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        return false;
    }
    void getSlotsReference()
    {
        for (int i = 0; i < SlotList.Count; i++)
        {
            SlotListReference.Add(SlotList[i].GetComponent<SlotController>());
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

    // Returns dice of slot (by index)
    //public GameObject GetSlotDice(int i)
    //{
    //    var child = this.gameObject.transform.GetChild(i);
    //    return child.GetComponent<SlotController>().dice;
    //}

    public void RollDice()
    {
        //Debug.Log("RollDice Node start");
        //can change to store game objects in SlotList
        //get the slotcontroller and then the HasDice
        for (int i = 0; i< slotcounter; i++)
        {
            //Debug.Log("RollDice Node for");

            if (SlotListReference[i].HasDice)
            {
                Debug.Log("RollDice Node calling slot");

                SlotListReference[i].RollDice();
            }
        }
    }

    public void BuyNode()
    {
        IsOn = true;
    }

    public void BuySlot()
    {
        if (slotcounter >= MAX_SLOTS)
        {
            Debug.Log("Too many slots!");
            return;
        }
        SlotListReference[slotcounter].setStatus(true);
        slotcounter++;
        Debug.Log("Bought slot " + slotcounter);
        return;
    }
    
}
