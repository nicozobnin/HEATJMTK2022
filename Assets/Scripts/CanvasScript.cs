using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateResources();
    }

    public void UpdateResources()
    {
        for (int i = 0; i < 3; i++) // This stuff is hardcoded as heck. Sad!
        {
            Transform child = this.gameObject.transform.GetChild(i+1);
            child.transform.GetChild(1).gameObject.GetComponent<TMPro.TMP_Text>().text = player.GetComponent<PlayerScript>().resources[i].ToString();
        }

    }
}
