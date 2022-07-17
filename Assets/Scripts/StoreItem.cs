using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    public List<List<int>> cost = new()
    {
        new List<int> { 0, 1 },
        new List<int> { 1, 1 },
        new List<int> { 2, 1 }
    };
    public Sprite icon;
    public string daname;
    public int id;
    public bool purchased;
    //public Event effect; maybe?

}
