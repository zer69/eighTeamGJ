using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int currentScore = 0;

    public i_GameEvent scoreEvent;

    public bool multiplied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            scoreEvent.Raise(other.GetComponent<CoinController>().coinPrice);
            Destroy(other.gameObject);
        }
    }

    public void GetPoints(int value)
    {
        if (!multiplied)
            currentScore += value;
        else
            currentScore += value * 2;
    }
}
