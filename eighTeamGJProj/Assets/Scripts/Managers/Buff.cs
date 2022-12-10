using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff: MonoBehaviour
{
    public enum BuffType
    {
        Sphere,
        MultiCoin,
        SpeedBoost,
        BearTrap
    }

    public BuffType buffType;
    public float Duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
