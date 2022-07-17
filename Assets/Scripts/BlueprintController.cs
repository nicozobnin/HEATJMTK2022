using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintController : MonoBehaviour
{

    //test
    public bool IsTest=false;
    //test


    // Hello I exist!
    public bool ready = false;
    public GameObject node; // For testing purposes

    //resolves issue of 2D array
    public int[] facesType = new int[6];
    public int[] facesTiar= new int[6];


    // Format: (Face ID, Tier)
    public List<List<int>> faces = new()
    {
        //new List<int> { 0, 0 }
    };


    // Format: (Resource ID, quantity)
    public int diceCost = 0;
    public List<List<int>> cost = new()
    {
        new List<int> { 0, 1 },
        new List<int> { 1, 1 },
        new List<int> { 2, 1 }
    };


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            AddFace(node.GetComponent<NodeController>().RollBlueprint());
            Debug.Log("Added face: " + faces[i][0] + "," + faces[i][1]);
        }
        AddFace(node.GetComponent<NodeController>().RollBlueprint());
        CraftDice();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void AddFace(List<int> face)
    {
        if (ready)
        {
            Debug.Log("Dice is already full!");
        }

        faces.Add(face);

        diceCost += face[0] + face[1];

        if (faces.Count >= 6)
        {
            ready = true;
        }
    }

    public GameObject CraftDice()
    {
        if (!ready)
        {
            Debug.Log("Not ready to craft dice!");
            return null;
        }

        foreach (List<int> i in cost)
        {
            /*if (PlayerResources[i[0]] <= i[1]) {
                Debug.Log("Not enough of resource " + i[0] + "!");
                return null;
            }
            */
        }

        //SubtractResources()
        //Dice output = new Dice(faces);
        //return output;
        Debug.Log("Dice crafted!");
        return null;
    }


}
