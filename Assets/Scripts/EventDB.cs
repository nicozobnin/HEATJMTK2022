using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventScaleEnum { slot, node, global };

public abstract class Event
{
    protected int meventId;
    protected EventScaleEnum meventScale;
    protected float mweight;

    public int getID()
    {
        return meventId;
    }

    public EventScaleEnum getScale()
    {
        return meventScale;
    }

    public float getWeight()
    {
        return mweight;
    }

    public abstract void FireEvent();
}

public abstract class EventList
{
    protected int mlistId;
    protected int msafeWeight; //The chance that nothing happens.
    protected List<Event> eventsList = new()
    {

    };

    public EventList(int listid, int safeweight)
    {
        mlistId = listid;
        msafeWeight = safeweight;
    }

    public int getID()
    {
        return mlistId;
    }

    public Event RollEvents() //Rolls for an event on the EventList
    {
        float totalWeight = msafeWeight;
        for (int i = 0; i < eventsList.Count; i++)
        {
            totalWeight += eventsList[i].getWeight();
        }
        //Debug.Log(totalWeight);
        float itemWeightIndex = Random.Range(0.0f, totalWeight);
        float currentIndexWeight = 0.0f;
        for (int i = 0; i < eventsList.Count; i++)
        {
            currentIndexWeight += (float)i;
            if (currentIndexWeight >= itemWeightIndex)
            {
                return eventsList[i];
            }
        }


        return null;

    }
}


//MASTER EVENT LISTS DB PAST THIS POINT
//DONT ADD ANYTHING ELSE

//MASTER EVENT DB PAST THIS POINT
//DONT ADD ANYTHING ELSE

public class DefaultEvent : Event
{
    public DefaultEvent()
    {
        meventId = 0;
        meventScale = (EventScaleEnum)3;
        mweight = 0.0f;
    }

    public override void FireEvent()
    {
        Debug.Log("Default Event fired. Nothing should happen.");
    }

}