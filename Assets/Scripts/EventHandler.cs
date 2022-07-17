using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/*ResourceDistribution
EventHandler
EventGetter
RandomEventGetter
GlobalEventFlag
GlobalEventGetter*/

public class EventHandler : MonoBehaviour
{
    public bool FIRERoll = false;

    public bool IsRolling = false;
    public bool CollectResult = false;

    public int mGlobalThreat;
    public PlayerScript playerRefence;
    public List<NodeController> Nodelist = new List<NodeController>();

    //m_MyEvent

    [System.Serializable]
    public class OntEvent : UnityEvent<NodeController> { };

    public OntEvent onTestEvent = new OntEvent();
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(" EventHandler Start ... ");
    }
    void awake()
    {
        Debug.Log(" EventHandler Processing ... ");
        //Fill the Events list.
        globalEventsList.Add(new DefaultEvent());

        onTestEvent.AddListener(RegisterNode);
        //okay listener idea will be solved later

        //Fills the Event Pools list.
        //globalEventsList.Add(new)

    }

    public void RegisterNode(NodeController myself)
    {
        Nodelist.Add(myself);
    }

    // Update is called once per frame
    public float timer = 0.0f;
    public float timelimit = 1.2f;
    // Update is called once per frame
    void Update()
    {


        if (FIRERoll)
        {
            RollDice();
            FIRERoll = false;
            //tester
        }
        if (IsRolling)
        {
            timer += Time.deltaTime;
            if (timer > timelimit)
            {
                CollectResult = CanCollectResult();
                timer = 0.0f;
            }
        }
        if (CollectResult)
        {
            AddUpResults();
            CollectResult = false;
        }

    }


    public List<Event> globalEventsList = new()
    {
    };
    public List<EventList> globalEventPoolsList = new()
    {

    };
    public void AddUpResults()
    {
        List<int> resourcesL = new List<int>();


        for (int i = 0; i < Nodelist.Count; i++)
        {
            resourcesL = Nodelist[i].AddUpResultsL();

            //switch to add to player
        }

        //call player
        //Debug.Log("total stone " + s);

        //playerRefence.AddStone(resourcesL[0]);
        //playerRefence.AddWood(resourcesL[1]);
        //playerRefence.AddFood(resourcesL[2]);

        //playerRefence.AddResource(resourcesL);

        Debug.Log("total stone " + resourcesL[0]);
        Debug.Log("total wood " + resourcesL[1]);
        Debug.Log("total food " + resourcesL[2]);
    }

    public bool CanCollectResult()
    {
        for (int i = 0; i < Nodelist.Count; i++)
        {
            if (!Nodelist[i].CanCollectResult())
            {
                return false;
            }
        }
        return true;
    }
    public void RollDice()
    {
        IsRolling = true;
        for (int i = 0; i < Nodelist.Count; i++)
        {
            Nodelist[i].RollDice();
        }
    }

    public void InitalizeEventList() //Initalizes the global list of events.
    {

    }

    public void ResourceDistribution() //Applies a global resource modifier.
    {

    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    public void FireEvent(int targetEventID, int targetNodeID) //Fires a specific event by ID
    {

    }

    public void EventRoll(int localThreat, int targetListID, int targetNodeID) //Rolls for a random event, from the specified event list.
    {

    }

}
