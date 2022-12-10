using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int hp;

    public b_GameEvent damageEvent;

    public b_GameEvent gameOver;



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
        if (hp == 0)
            gameOver.Raise(true);
        
    }
}
