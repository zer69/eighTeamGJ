using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float xSpawnCoinsLeftBound = -10f;
    public float xSpawnCoinsRightBound = 10f;
    public float zSpawnCoinsTopBound = 10f;
    public float zSpawnCoinsBotBound = -10f;
    public float ySpawnCoinsHeight = 10f;
    public float coinSpawnInterval = 4f;

    public GameObject coin;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", coinSpawnInterval, coinSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCoins()
    {
        float randomX = Random.Range(xSpawnCoinsLeftBound, xSpawnCoinsRightBound);
        float randomZ = Random.Range(zSpawnCoinsBotBound, zSpawnCoinsTopBound);

        Vector3 powerupPos = new Vector3(randomX, ySpawnCoinsHeight, randomZ);

        Instantiate(coin, powerupPos, coin.gameObject.transform.rotation);
    }
}
