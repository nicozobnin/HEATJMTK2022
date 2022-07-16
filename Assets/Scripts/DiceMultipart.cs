using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMultipart : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> facesList = new List<GameObject>();
    public Texture2D[] faceAssets = new Texture2D[6];
    public Material[] faceMaterial = new Material[6];
    


    // Update is called once per frame
    public float timer = 0.0f;
    public float timelimit = 0.5f;

    //end of testing zone
    void Start()
    {

    }



    void Update()
    {

        timer += Time.deltaTime;
        //testing zone
        if (timer > timelimit)
        {
            Debug.Log(" seconds passed");
            setRandomFaces();
            timer = 0;
        }
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
}
