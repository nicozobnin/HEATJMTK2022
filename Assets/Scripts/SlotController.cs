using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public DiceMultipart dice;
    public bool HasDice = false;
    // Start is called before the first frame update
    //trigger
    public BoxCollider boxCol;

    public GameObject m_gameObject;




    public bool IsOn = false;
    
    void Start()
    {
        m_gameObject = this.GetComponent<GameObject>();
        boxCol = GetComponent<BoxCollider>();
        if(!boxCol)
        {
            boxCol = m_gameObject.AddComponent<BoxCollider>();
            boxCol.isTrigger = true;
        }
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!IsOn)
        { return; }
        if(!other)
        {
            Debug.Log("cant access game object");
        }
        if(other.GetComponent<DiceMultipart>().IsAvailableForGrab && HasDice==false)
        {
            //the other thing is a dice
            //dice is also available to be caught
            dice = other.GetComponentInParent<DiceMultipart>();
            CatchDice();
        }
    }

    public void setStatus(bool onoff)
    {
        IsOn = onoff;
        if (onoff)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            Debug.Log("set colore green");
            return;
        }
        Debug.Log("set colore red");
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

    }
    public void CatchDice()
    {
        dice.RestrictDice();

        Vector3 newposition = transform.position + new Vector3(0, 1, 0);

        dice.transform.position = newposition;
        HasDice = true;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

    }
    public void RollDice()
    {
        Debug.Log("RollDice slot calling Dice script");
        dice.UnrestricDice();
        dice.RollDice();
    }
    public void ReleaseDice()
    {

    }
}
