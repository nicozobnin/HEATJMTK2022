using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" EventHandler Start ... ");
    }
    void awake()
    {
        Debug.Log(" EventHandler Processing ... ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResourceDistribution() //Distributes 
    {

    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
