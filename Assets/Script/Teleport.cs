using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportSpot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name  =="player")
        {
            other.gameObject.transform.position = TeleportSpot.gameObject.transform.position;
            TeleportSpot.gameObject.SetActive(false);
        }
    }
}
