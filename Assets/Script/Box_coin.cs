using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_coin : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Box;

    private Vector3 CoinTransform;
    bool tr = true;

    void Start()
    {
        CoinTransform = Box.transform.position + new Vector3(0, 1, 0);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bullet(Clone)")
        {
            StartCoroutine(AddCoin());
        }
    }

    IEnumerator AddCoin()
    {
        Instantiate(Coin, CoinTransform, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Instantiate(Coin, CoinTransform, Quaternion.identity);
        gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
