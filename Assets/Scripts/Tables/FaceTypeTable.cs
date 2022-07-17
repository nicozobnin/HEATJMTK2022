using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//phase out lists
//impose FaceType list
public struct FaceType
{
    Texture2D faceAsset;
    Material faceMaterial;

    int FaceID;
    string FaceName;
}


public class FaceTypeTable : MonoBehaviour
{
    //0 - pickaxe
    //1 - axe
    //2 - sickle
    //3 - shield
    //4 - blueprint
    //5 - miss

    public FaceTypeTable instance;



    public int[] FaceTypeID = new int[6];
    public string[] FaceTypeName = new string[6];



    //while setting a reference from here to the textures would be ideal
    //might be faster to create a local reference in each script for now 
    public Texture2D[] faceAssets = new Texture2D[6];
    public Material[] faceMaterial = new Material[6];


    // Start is called before the first frame update
    public void Start()
    {
        //fail save
        for (int i = 0; i < FaceTypeID.Length; i++)
        {
            FaceTypeID[i] = i;
        }
        FaceTypeID[0] = 0;
        FaceTypeName[0] = "Pickaxe";


        FaceTypeID[1] = 0;
        FaceTypeName[1] = "axe";

        FaceTypeID[2] = 0;
        FaceTypeName[2] = "sickle";

        FaceTypeID[3] = 0;
        FaceTypeName[3] = "shield";

        FaceTypeID[4] = 0;
        FaceTypeName[4] = "blueprint";

        FaceTypeID[5] = 0;
        FaceTypeName[5] = "Pickaxe";



    }


    // Update is called once per frame
    void Update()
    {

    }
    public int[] GetFaceListIDs()
    {
        return FaceTypeID;
    }
    public string[] GetFaceListNames()
    {
        return FaceTypeName;
    }
    public Texture2D[] GetFaceListAsset()
    {
        return faceAssets;
    }
    public Material[] GetFaceListMaterial()
    {
        return faceMaterial;
    }

}
