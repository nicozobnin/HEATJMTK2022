using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ResourceDistribution
EventHandler
EventGetter
RandomEventGetter
GlobalEventFlag
GlobalEventGetter*/

public class EventHandler : MonoBehaviour
{
    public int mGlobalThreat;
    public List<Event> globalEventsList = new()
    {
    };

    // Start is called before the first frame update
    void Start()
    {
        globalEventsList.Add(new DefaultEvent());


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitalizeEventList() //Initalizes the global list of events.
    {
        
    }

    public void ResourceDistribution() //Applies a global resource modifier.
    {

    }

    public void FireEvent(int targetEventID) //Fires a specific event by ID
    {

    }

    public void EventRoll(int localThreat, int targetListID) //Rolls for a random event, from the specified event list.
    {

    }
    
}
