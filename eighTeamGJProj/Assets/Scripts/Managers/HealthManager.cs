using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int hp = 4;

    public b_GameEvent damageEvent;



    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Projectile") || (other.tag == "HealthKit"))
        {
            damageEvent.Raise(other.GetComponent<Health>().hp);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(bool value)
    {
        hp += (value ? 1 : -1);
    }
}
