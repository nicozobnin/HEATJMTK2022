using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //this script seeks to remap each die at run time
    //the UV will be edited to then set the right texture
    //die are consider 1 item
    //requires costume die

    //List of 6 faces
    List<int> facesList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
    //List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });
    public Texture2D[] faceAssets = new Texture2D[6];
    public Texture2D TextureAtlas;
    public Rect[] AtlasUvs = new Rect[14];


    Dice(List<int> NewFaces)
    {
        facesList = NewFaces;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUVs();
    }
    void SetUVs()
    {
        AtlasUvs[0] = new Rect(0, 0.66f, 0, 0);
        AtlasUvs[1] = new Rect(0.25f, 0.66f, 0, 0);
        AtlasUvs[2] = new Rect(0, 0.33f, 0, 0);
        AtlasUvs[3] = new Rect(0.25f, 0.33f, 0, 0);

        AtlasUvs[4] = new Rect(0.5f, 0.66f, 0, 0);
        AtlasUvs[5] = new Rect(0.5f, 0.33f, 0, 0);
        AtlasUvs[6] = new Rect(0.75f, 0.66f, 0, 0);
        AtlasUvs[7] = new Rect(0.75f, 0.33f, 0, 0);

        AtlasUvs[8] = new Rect(1, 0.66f, 0, 0);
        AtlasUvs[9] = new Rect(1, 0.33f, 0, 0);
        AtlasUvs[10] = new Rect(0.25f, 1, 0, 0);
        AtlasUvs[11] = new Rect(0.5f, 1, 0, 0);

        AtlasUvs[12] = new Rect(0.25f, 0, 0, 0);
        AtlasUvs[13] = new Rect(0.5f, 0, 0, 0);

        AtlasUvs = TextureAtlas.PackTextures(faceAssets, 2, 8192);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void TextureCreation()
    {
        //TextureAtlas.PackTextures(faceAssets);
    }
    
}
