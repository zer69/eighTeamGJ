using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int coinPrice;
    public bool expiring = false;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((_rb.velocity == Vector3.zero) && (!expiring))
        {
            StartExpiration();
            expiring = true;
        }
    }

    void DestroyCoin()
    {
        Destroy(gameObject);
    }

    public void StartExpiration()
    {
        StartCoroutine(Expire());
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(5f);
        DestroyCoin();
    }

}
