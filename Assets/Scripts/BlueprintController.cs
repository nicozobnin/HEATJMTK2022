using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{
    public List<List<int>> faces = new()
    {
        //new List<int> { 0, 0 }
    };
    /* Format: (Face ID, Tier)
     * */
    public bool ready = false;

    public void AddFace(List<int> face)
    {
        faces.Add(face);
        if (faces.Count == 6)
        {
            ready = true;
        }
    }

    public GameObject CraftDice()
    {
        if (!ready)
        {
            return null;
        }
        else if (false) // Check if there are enough resources
        {
            return null;
        }

        //SubtractResources()
        //Dice output = new Dice(faces);
        //return output;
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
