using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPanel : MonoBehaviour
{
    public NodeController node;
    public PlayerScript player;
    public List<List<int>> unlockCost;


    // Start is called before the first frame update
    void Start()
    {
        unlockCost = node.unlockCost;
        UpdateResources();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNode(NodeController n)
    {
        node = n;
    }

    public void UpdateResources()
    {
        for (int i = 0; i < 3; i++) // This stuff is hardcoded as heck. Sad!
        {
            Transform child = this.gameObject.transform.GetChild(i);
            child.transform.GetChild(1).gameObject.GetComponent<TMPro.TMP_Text>().text = unlockCost[i][1].ToString();
        }
    }

    public void BuyNode()
    {
        if (!player.CheckResources(unlockCost))
        {
            Debug.Log("Not enough resources!");
            return;
        }

        Debug.Log("Buying node!");
        player.SubtractResources(unlockCost);
        node.BuyNode();
        return;
    }
}
