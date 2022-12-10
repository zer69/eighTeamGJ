using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinPrice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyCoin();
    }

    void DestroyCoin()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
