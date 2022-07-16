using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //List of 6 faces
    List<int> facesList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
    //List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });
    public Texture2D[] faceAssets = new Texture2D[6];
    public Texture2D TextureAtlas;
    public Rect[] AtlasUvs = new Rect[6];


    Dice(List<int> NewFaces)
    {
        facesList = NewFaces;
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
