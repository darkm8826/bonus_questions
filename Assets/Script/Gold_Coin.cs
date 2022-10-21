using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Coin : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
