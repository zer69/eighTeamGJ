using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int currentScore = 0;

    public i_GameEvent scoreEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            scoreEvent.Raise(other.GetComponent<Coin>().value);
            Destroy(other.gameObject);
        }
    }

    public void GetPoints(int value)
    {
        currentScore += value;
    }
}
