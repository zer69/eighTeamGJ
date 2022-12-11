using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{

    public bool speedCDRunning = false;

    public b_GameEvent speedChange;
    public b_GameEvent bearTrap;
    public b_GameEvent shieldGained;
    public b_GameEvent multiCoin;
    public b_GameEvent takeDamage;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {
            shieldGained.Raise(true);
            StartCoroutine(SphereCoolDown());
            Destroy(other.gameObject);
        }

        if (other.tag == "MultiCoin")
        {

            multiCoin.Raise(true);
            StartCoroutine(MultiCoinCoolDown());
            Destroy(other.gameObject);
        }

        if (other.tag == "SpeedBoost")
        {

            speedChange.Raise(true);
            StartCoroutine(SpeedCoolDown());
            Destroy(other.gameObject);
        }

        if (other.tag == "BearTrap")
        {

            bearTrap.Raise(true);
            takeDamage.Raise(false);
            StartCoroutine(BearTrapCoolDown());
            Destroy(other.gameObject);
        }
    }

    IEnumerator SphereCoolDown()
    {
        yield return new WaitForSeconds(5f);
        shieldGained.Raise(false);
    }

    IEnumerator MultiCoinCoolDown()
    {
        yield return new WaitForSeconds(10f);
        multiCoin.Raise(false);
    }

    IEnumerator SpeedCoolDown()
    {
        yield return new WaitForSeconds(3f);
        speedChange.Raise(false);
    }

    IEnumerator BearTrapCoolDown()
    {
        yield return new WaitForSeconds(3f);
        bearTrap.Raise(false);
    }

}