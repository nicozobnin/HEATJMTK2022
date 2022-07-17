using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMultipart : MonoBehaviour
{
    public GameObject EventHandlerReference;

    //test
    public bool IsTest = false;
    //test

    public TextAsset jsonFile;


    //load FaceType
    public FaceTypeTable listClass;
    public int[] LoadFaceID = new int[6];
    public string[] LoadFaceName = new string[6];
    //public List<string> LoadFaceName = new List<string>();


    //manual reference to the assets and materials
    public List<GameObject> facesList = new List<GameObject>();
    public Texture2D[] faceAssets = new Texture2D[6];
    public Material[] faceMaterial = new Material[6];

    public List<int> faceID= new List<int>();
    public List<int> facetear= new List<int>();
    public List<string> faceName= new List<string>();
    //fail save change
    //public string[] faceName = new string[6];


    // Update is called once per frame
    public float timer = 0.0f;
    public float timelimit = 0.5f;

    //end of testing zone
    void Start()
    {
        //listClass = FaceTypeTable.instance;
        LoadFaceID = listClass.FaceTypeID;
        LoadFaceName = listClass.FaceTypeName;
        SunnySideUp();
    }



    void Update()
    {
        if (IsTest)
        {
            DrawTest();

            timer += Time.deltaTime;
            //testing zone
            if (timer > timelimit)
            {
                //Debug.Log(" seconds passed");
                //setRandomFaces();
                timer = 0;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log(" create dice ");
                List<int> faType = new List<int> { 0, 0, 2, 2, 4, 4 };
                List<int> faTier = new List<int> { 0, 0, 0, 0, 0, 0 };
                CreateDice(faType, faTier);
                int n =TempRollResult();
                Debug.Log("result ID is " + n);
            }
        }
    }

    public bool CreateDice(List<List<int>> blueprint)
    {

        return false;
    }
    public bool CreateDice(List<int> faType, List<int> faTier)
    {
        if((faType.Count<1) || (faTier.Count < 1) || faceName.Count >6)
        {
            return false;
        }
        faceID = faType;
        facetear = faTier;

        for(int i = 0; i < faceID.Count; i++)
        {

            faceName.Add(LoadFaceName[faceID[i]]);
            //faceName[i] = LoadFaceName[faceID[i]];
            //Debug.Log(" LoadFaceName[i] " + LoadFaceName[i]);
        }

        for (int i = 0; i < faType.Count; i++)
        {
            //Debug.Log(" faType size :"    + faType.Count);
            //Debug.Log(" facesList size :" + facesList.Count);
            //Debug.Log(" start ");
            //Debug.Log(" i " + i);
            //Debug.Log(" faType[i] " + faType[i]);

            facesList[i].GetComponent<Renderer>().material = faceMaterial[faType[i]];
            //Debug.Log(" end ");
        }
        return true;
    }

    void setRandomFaces()
    {
        //testing mode, will select random faces
        //final version will take an array, and set the material correctly
        //save the position of each item
        for(int i = 0; i < facesList.Count; i++)
        {
            int r = Random.Range(0, 6);
            Debug.Log(" r is " + r);
            facesList[i].GetComponent<Renderer>().material = faceMaterial[r];

        }
    }
    void SunnySideUp()
    {
        
        float angle = 181.0f;
        int i = 0;
        Debug.Log(" angle test start... ");

        //u got sides in array, check in order of that array and then return that pos

        angle = Vector3.Angle(transform.up, Vector3.up);
        Debug.Log(" angle  " + angle);

        angle = Vector3.Angle(transform.up, -transform.up);
        Debug.Log(" angle  " + angle);

        angle = Vector3.Angle(transform.up, transform.right);
        Debug.Log(" angle  " + angle);

        angle = Vector3.Angle(transform.up, -transform.right);
        Debug.Log(" angle  " + angle);

        angle = Vector3.Angle(transform.up, transform.forward);
        Debug.Log(" angle  " + angle);

        angle = Vector3.Angle(transform.up, -transform.forward);
        Debug.Log(" angle  " + angle);
    }
    int QuickRandomFaceUp()
    {
        //instead of rolling dice and determining what side is up
        //this function selectes a random face, and then sets that as the face up
        int r = Random.Range(0, faceID.Count);
        return r;

    }
    void DrawTest()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.green);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right), Color.red);
    }

    void RollDice()
    {
        //if real roll:
        //eleveate dice, roll
        //unfreeze Y
        //let dice sit, then calculate side up

        //if fake roll
        //calculate number and return here
        //make dice invisible
        //  iether
        //      go below the map and come back with the right side up
        //  or
        //      make invisible, make right side up, then make them visible
    }
    int RollResult()
    {
        return 5;
    }
    int TempRollResult()
    {
        
        int r = Random.Range(0, faceID.Count);
        return faceID[r];
    }

}
