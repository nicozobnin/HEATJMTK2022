using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int resourceCount = 3;
    public List<int> resources = new();
    


    void Start()
    {
        for (int i = 0; i < resourceCount; i++) //Fills the resources with 0s 
        {
            resources.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Adds [ID, Quantity] resource.
    public void AddResource(List<int> r)
    {
        resources[r[0]] += r[1];
    }

    // Adds [[ID, Quantity], []. ...] resources.
    public void AddResources(List<List<int>> r)
    {
        foreach (List<int> i in r)
        {
            AddResource(i);
        }
    }

    // Check if player has requested resource
    public bool CheckResource(List<int> r)
    {
        if (resources[r[0]] < r[1])
        {
            return false;
        }
        return true;
    }

    // Checks if player has requested resources
    public bool CheckResources(List<List<int>> r)
    {
        foreach (List<int> i in r)
        {
            if (!CheckResource(i))
            {
                return false;
            }
        }
        return true;
    }

    public bool SubtractResource(List<int> r)
    {
        if (!CheckResource(r)) // Fails if player doesn't have the resources
        {
            return false;
        }

        resources[r[0]] -= r[1];
        return true;
    }


    // Subtracts resources from player, returns false if it can't.
    public bool SubtractResources(List<List<int>> r)
    {
        if (!CheckResources(r)) // False if you can't
        {
            return false;
        }

        foreach (List<int> i in r)
        {
            SubtractResource(i);
        }
        return true;
    }
}
