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

    public AudioSource sphere;
    public AudioSource multi;
    public AudioSource speed;
    public AudioSource trap;


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
        sphere.volume = 0f;
        shieldGained.Raise(false);
        yield return new WaitForSeconds(2f);
        sphere.volume = 1f;
    }

    IEnumerator MultiCoinCoolDown()
    {
        yield return new WaitForSeconds(multiCoinDuration);
        multi.volume = 0f;
        multiCoin.Raise(false);
        yield return new WaitForSeconds(2f);
        multi.volume = 1f;
    }

    IEnumerator SpeedCoolDown()
    {
        yield return new WaitForSeconds(speedDuration);
        speed.volume = 0f;
        speedChange.Raise(false);
        yield return new WaitForSeconds(2f);
        speed.volume = 1f;
    }

    IEnumerator BearTrapCoolDown()
    {
        yield return new WaitForSeconds(bearTrapDuration);
        trap.volume = 0f;
        bearTrap.Raise(false);
        yield return new WaitForSeconds(2f);
        trap.volume = 1f;
    }

}