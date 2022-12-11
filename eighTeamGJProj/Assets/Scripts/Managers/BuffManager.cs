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

    [Header("buff Duration")]
    public float speedDuration = 3f;
    public float bearTrapDuration = 3f;
    public float shieldDuration = 5f;
    public float multiCoinDuration = 10f;

    private bool sphereUp = false;
    private bool multiUp = false;
    private bool speedUp = false;
    private bool trapUp = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {
            shieldGained.Raise(true);
            if (sphereUp)
            {
                StopCoroutine(SphereCoolDown());
                StartCoroutine(SphereCoolDown());
            }
            else
            {
                StartCoroutine(SphereCoolDown());
                sphereUp = true;
            }
            
            Destroy(other.gameObject);
        }

        if (other.tag == "MultiCoin")
        {

            multiCoin.Raise(true);
            if (multiUp)
            {
                StopCoroutine(MultiCoinCoolDown());
                StartCoroutine(MultiCoinCoolDown());
            }
            else
            {
                StartCoroutine(MultiCoinCoolDown());
                multiUp = true;
            }
            
            Destroy(other.gameObject);
        }

        if (other.tag == "SpeedBoost")
        {

            speedChange.Raise(true);
            if (speedUp)
            {
                StopCoroutine(SpeedCoolDown());
                StartCoroutine(SpeedCoolDown());
            }
            else
            {
                StartCoroutine(SpeedCoolDown());
                speedUp = true;
            }
            
            Destroy(other.gameObject);
        }

        if (other.tag == "BearTrap")
        {

            bearTrap.Raise(true);
            if (trapUp)
            {
                StopCoroutine(BearTrapCoolDown());
                StartCoroutine(BearTrapCoolDown());
            }
            else
            {
                StartCoroutine(BearTrapCoolDown());
                trapUp = true;
            }
            
            takeDamage.Raise(false);
            Destroy(other.gameObject);
        }
    }

    IEnumerator SphereCoolDown()
    {
        yield return new WaitForSeconds(shieldDuration);
        shieldGained.Raise(false);
    }

    IEnumerator MultiCoinCoolDown()
    {
        yield return new WaitForSeconds(multiCoinDuration);
        multiCoin.Raise(false);
    }

    IEnumerator SpeedCoolDown()
    {
        yield return new WaitForSeconds(speedDuration);
        speedChange.Raise(false);
    }

    IEnumerator BearTrapCoolDown()
    {
        yield return new WaitForSeconds(bearTrapDuration);
        bearTrap.Raise(false);
    }

}