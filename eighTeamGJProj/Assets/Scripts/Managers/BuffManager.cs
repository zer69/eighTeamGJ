using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{

    public bool speedCDRunning = false;

    public i_GameEvent speedChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {
            this.GetComponent<HealthManager>().protectedByShield = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "MultiCoin")
        {

            this.GetComponentInChildren<PointManager>().multiplied = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "SpeedBoost")
        {

            speedChange.Raise(1);
            if (speedCDRunning)
            {
                StopCoroutine(ReturnToNormalSpeed());
                StartCoroutine(ReturnToNormalSpeed());
            }
            else
                StartCoroutine(ReturnToNormalSpeed());
            Destroy(other.gameObject);
        }

        if (other.tag == "BearTrap")
        {

            speedChange.Raise(-1);
            if (speedCDRunning)
            {
                StopCoroutine(ReturnToNormalSpeed());
                StartCoroutine(ReturnToNormalSpeed()); 
            }
            else
                StartCoroutine(ReturnToNormalSpeed());

            Destroy(other.gameObject);
        }

        IEnumerator ReturnToNormalSpeed()
        {
            speedCDRunning = true;
            yield return new WaitForSeconds(3f);
            speedChange.Raise(0);
            speedCDRunning = false;
        }

    }
}
