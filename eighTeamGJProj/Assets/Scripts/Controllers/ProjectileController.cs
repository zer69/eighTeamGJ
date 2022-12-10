using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;

    private Rigidbody bootRb;
    private float xBound = 30f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        bootRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bootRb.AddForce(Vector3.left * speed, ForceMode.Impulse);
        if (transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
    }
}
