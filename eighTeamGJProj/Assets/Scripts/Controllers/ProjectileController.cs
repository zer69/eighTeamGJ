using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;

    public Rigidbody bootRb;
    public SpawnManager spawnManager;
    private Vector3 side;
    private float xBound = 100f;
    private float zBound = 100f;
    private int direction;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        bootRb = GetComponent<Rigidbody>();
        BootDirection();
    }

    // Update is called once per frame
    void Update()
    {
        bootRb.AddForce(side * speed, ForceMode.Impulse);
        if (transform.position.x > xBound || transform.position.x < -xBound || transform.position.z > zBound)
        {
            Destroy(gameObject);
        }
    }

    void BootDirection()
    {
        direction = spawnManager.projectileDirection;
        switch (direction)
        {
            case 4:
                side = Vector3.back;
                break;
            case 3:
                side = Vector3.forward;
                break;
            case 2:
                side = Vector3.right;
                break;
            case 1:
                side =  Vector3.left;
                break;
        }


    }
}
