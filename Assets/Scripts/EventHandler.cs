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
    public List<EventList> globalEventPoolsList = new()
    {

    };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" EventHandler Start ... ");
    }
    void awake()
    {
        Debug.Log(" EventHandler Processing ... ");
        //Fill the Events list.
        globalEventsList.Add(new DefaultEvent());

        //Fills the Event Pools list.
        //globalEventsList.Add(new)

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
