using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    public float rotationRate;
    public bool rotationDirection;

    void Awake()
    {
        rotationDirection = randomBool();
    }

    void Update()
    {
        transform.Rotate(0,rotationRate * Time.deltaTime * (rotationDirection ? 1:-1) ,0);
    }

    bool randomBool()
    {
        if (Random.Range(0f, 1.0f) > 0.5f)
        {
            return true;
        }
        return false;
    }
}
