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
    public int projectileDirection;

    public GameObject[] coins;
    public GameObject boot;

        
    public bool gameOver = false;

    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", coinSpawnInterval, coinSpawnInterval);
        InvokeRepeating("SpawnProjectiles", projectileSpawnInterval, projectileSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
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
        float randomX = Random.Range(-xProjectileSpawnRange, xProjectileSpawnRange);

        if (currentTime < 5f)
        {

            Vector3 bootPos = new Vector3(xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);

            projectileDirection = 1;

            Instantiate(boot, bootPos, boot.gameObject.transform.rotation);
        }

        else if(currentTime < 10f)
        {

            int randomSide = Random.Range(0, 2);

            if(randomSide == 1)
            {
                Vector3 bootPos = new Vector3(-xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);
                projectileDirection = 2;
                Instantiate(boot, bootPos, boot.gameObject.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            }

            else
            {
                Vector3 bootPos = new Vector3(xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);
                projectileDirection = 1;
                Instantiate(boot, bootPos, boot.gameObject.transform.rotation);
            }
        }

        else
        {
            int randomSide = Random.Range(1, 5);

            switch (randomSide)
            {
                //case 4:
                //    projectileDirection = 4;
                //    Vector3 bootPos4 = new Vector3(randomX, ySpawnProjectileHeight, zSpawnCoinsTopBound);

                //    Instantiate(boot, bootPos4, boot.gameObject.transform.rotation);
                //    break;
                case 3:
                    projectileDirection = 3;
                    Vector3 bootPos3 = new Vector3(randomX, ySpawnProjectileHeight, zSpawnCoinsBotBound);

                    Instantiate(boot, bootPos3, boot.gameObject.transform.rotation * Quaternion.Euler(0f, 90f, 0f));
                    break;
                case 2:
                    projectileDirection = 2;
                   

                    Vector3 bootPos2 = new Vector3(-xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);

                    Instantiate(boot, bootPos2, boot.gameObject.transform.rotation * Quaternion.Euler(0f, 180f, 0f));
                    break;
                case 1:
                    projectileDirection = 1;

                    Vector3 bootPos1 = new Vector3(xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);

                    Instantiate(boot, bootPos1, boot.gameObject.transform.rotation);
                    break;
            }
        }
    }

    void Timer()
    {
        currentTime += Time.deltaTime;
    }
}
