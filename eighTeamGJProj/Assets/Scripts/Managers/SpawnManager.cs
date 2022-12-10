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

    public float ySpawnProjectileHeight = 2f;
    public float xProjectileSpawnRange = 10f;
    public float projectileSpawnInterval = 4f;

    public GameObject[] coins;
    public GameObject boot;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", coinSpawnInterval, coinSpawnInterval);
        InvokeRepeating("SpawnProjectiles", projectileSpawnInterval, projectileSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCoins()
    {
        float randomX = Random.Range(xSpawnCoinsLeftBound, xSpawnCoinsRightBound);
        float randomZ = Random.Range(zSpawnCoinsBotBound, zSpawnCoinsTopBound);

        int randomIndex = Random.Range(0, coins.Length);

        Vector3 coinPos = new Vector3(randomX, ySpawnCoinsHeight, randomZ);

        Instantiate(coins[randomIndex], coinPos, coins[randomIndex].gameObject.transform.rotation);
    }

    private void SpawnProjectiles()
    {
        float randomZ = Random.Range(zSpawnCoinsBotBound, zSpawnCoinsTopBound);

        Vector3 bootPos = new Vector3(xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);

        Instantiate(boot, bootPos, boot.gameObject.transform.rotation);
    }
}
