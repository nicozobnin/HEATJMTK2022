using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMultipart : MonoBehaviour
{
    public GameObject EventHandlerReference;//Direct reference
    public Rigidbody m_Rigidbody;

    public bool IsAvailableForGrab = true;

    public bool IsRolling = false;
    public bool CollectResult = false;


    //test
    public bool IsTest = false;
    //test



    //load FaceType
    public FaceTypeTable listClass;
    public int[] LoadFaceID = new int[6];
    public string[] LoadFaceName = new string[6];
    //public List<string> LoadFaceName = new List<string>();


    //manual reference to the assets and materials
    public List<GameObject> facesList = new List<GameObject>();
    public Texture2D[] faceAssets = new Texture2D[6];
    public Material[] faceMaterial = new Material[6];

    public List<int> faceID = new List<int>();
    public List<int> facetear = new List<int>();
    public List<string> faceName = new List<string>();

    public int faceUp = 5;
    //fail save change
    //public string[] faceName = new string[6];

    bool isLock;

    // Update is called once per frame
    public float timer = 0.0f;
    public float timelimit = 1.2f;

    GameObject m_gameObject;
    //end of testing zone
    void Start()
    {
        //listClass = FaceTypeTable.instance;
        LoadFaceID = listClass.FaceTypeID;
        LoadFaceName = listClass.FaceTypeName;
        //int i =SunnySideUp();
        //Debug.Log(" position " + i);
        m_gameObject = this.GetComponent<GameObject>();

        List<int> faType = new List<int> { 0, 0, 2, 2, 4, 4 };
        List<int> faTier = new List<int> { 0, 0, 0, 0, 0, 0 };
        CreateDice(faType, faTier);
        m_Rigidbody = GetComponent<Rigidbody>();
        if (!m_Rigidbody)
        {
            m_Rigidbody = m_gameObject.AddComponent<Rigidbody>();
        }
    }



    void Update()
    {
        if (IsRolling)
        {
            //Debug.Log("m_Rigidbody.velocity.magnitude" + m_Rigidbody.velocity.magnitude);
            timer += Time.deltaTime;
            //testing zone
            //Debug.Log("waiting");

            if (timer > timelimit)
            {
                //Debug.Log(" seconds passed");
                //setRandomFaces();
                timer = 0.0f;
                //Debug.Log("time done");

                if (m_Rigidbody.velocity.magnitude < 0.5f)
                {
                    Debug.Log("Dice is stopped");
                    CollectResult = true;
                }
            }
        }
        if (isLock)
        {
            m_Rigidbody.velocity = Vector3.zero;
            transform.Rotate(Time.deltaTime * 25, Time.deltaTime * 25, Time.deltaTime * 25, Space.Self);
        }

        if (IsTest)
        {
            DrawTest();

            //timer += Time.deltaTime;
            //testing zone
            if (timer > timelimit)
            {
                //Debug.Log(" seconds passed");
                //setRandomFaces();
                //timer = 0;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                //RollDice();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                //m_Rigidbody.AddForce(transform.forward * 100);
                //m_Rigidbody.AddForce(transform.right * 100);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                returnIDFaceUP();
            }
        }
    }
    public bool CanCollectResult()
    {
        return CollectResult;
    }

    public bool CreateDice(List<List<int>> blueprint)
    {

        return false;
    }
    public bool CreateDice(List<int> faType, List<int> faTier)
    {
        if ((faType.Count < 1) || (faTier.Count < 1) || faceName.Count > 6)
        {
            return false;
        }
        faceID = faType;
        facetear = faTier;

        for (int i = 0; i < faceID.Count; i++)
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
        for (int i = 0; i < facesList.Count; i++)
        {
            int r = Random.Range(0, 6);
            Debug.Log(" r is " + r);
            facesList[i].GetComponent<Renderer>().material = faceMaterial[r];

        }
    }
    public int returnIDFaceUP()
    {

        //this implies the dice is being asked for its face up
        //thus the turn is over
        //and the dice can be freed


        //maybe implement a function that freezes the dice movement when equipet
        //roll unfreezes Y

        //this function releases XZ

        //un equip func releases all 3

        Debug.Log(" Call Return dice up ");
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //m_Rigidbody.mass = 0.01f;
        //m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionZ;
        IsRolling = false;
        CollectResult = false;
        int o = faceID[SunnySideUp()];
        Debug.Log(" o  " + o);
        return o;
    }
    int SunnySideUp()
    {
        //Debug.Log(" angle  " + angle);
        //
        float angle = 181.0f;
        float temp = 0.0f;
        int i = 0;
        Debug.Log(" angle test start... ");

        //u got sides in array, check in order of that array and then return that pos

        temp = Vector3.Angle(transform.up, transform.forward);
        if (temp < angle)
        {
            angle = temp;
            i = 0;
        }
        temp = Vector3.Angle(transform.up, -transform.up);
        if (temp < angle)
        {
            angle = temp;
            i = 1;
        }
        temp = Vector3.Angle(transform.up, -transform.forward);
        if (temp < angle)
        {
            angle = temp;
            i = 2;
        }
        temp = Vector3.Angle(transform.up, Vector3.up);
        if (temp < angle)
        {
            angle = temp;
            i = 3;
        }
        temp = Vector3.Angle(transform.up, transform.right);
        if (temp < angle)
        {
            angle = temp;
            i = 4;
        }
        temp = Vector3.Angle(transform.up, -transform.right);
        if (temp < angle)
        {
            angle = temp;
            i = 5;
        }
        //fail save
        //allows to access the position in all 3 lists
        faceUp = i;
        return i;
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
    public void RestrictDice()
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //isLock = true;
        //m_Rigidbody.useGravity = false;
        m_Rigidbody.isKinematic = true;
    }
    public void UnrestricDice()
    {
        //isLock = false;
        //m_Rigidbody.useGravity = true;
        m_Rigidbody.isKinematic = false;

    }
    public void RollDice()
    {
        UnrestricDice();
        isLock = false;
        IsRolling = true;
        Debug.Log("Roll dice being call in Dice script");
        //RestrictDice();
        //m_Rigidbody.mass = 4f;

        //either or
        //m_Rigidbody.AddForce(transform.up *1000);
        m_Rigidbody.AddExplosionForce(1000, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), 3);
        m_Rigidbody.AddTorque(250, 250, 250);
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
    int TempRollResult()
    {
        int r = Random.Range(0, faceID.Count);
        return faceID[r];
    }

}
