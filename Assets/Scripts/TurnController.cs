using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public int turnCount = 1;
    public List<NodeController> nodes;
    public GameObject turnText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTurnCount()
    {
        turnText.GetComponent<TMPro.TMP_Text>().text = "Turn " + turnCount.ToString();
    }

    public void EndTurn()
    {
        foreach (NodeController node in nodes)
        {
            node.RollDice();
        }

        Debug.Log("Ending turn " + turnCount);
        turnCount++;
        UpdateTurnCount();
    }
}
