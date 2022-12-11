using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Area for coins")]
    public float xSpawnAreaLeftBound = -10f;
    public float xSpawnAreaRightBound = 10f;
    public float zSpawnAreaTopBound = 10f;
    public float zSpawnAreaBotBound = -10f;
    public float ySpawnCoinsHeight = 10f;
    [Header("Time for coins")]
    public float coinSpawnInterval = 4f;

    [Header("Area for projectiles")]
    public float ySpawnProjectileHeight = 2f;
    public float xProjectileSpawnRange = 10f;
    public float zProjectileSpawnRange = 15f;
    public int projectileDirection;
    [Header("Time for Projectiles")]
    public float projectileSpawnInterval = 4f;
    
    
    [Header("Time for Difficulty")]
    public float secondPhaseStartTime = 5f;
    public float thirdPhaseStartTime = 10f;

    public float ySpawnBuffsHeight = 1f;
    [Header("Time for Buffs")]
    public float buffSpawnInterval = 5f;
    public float debuffSpawnInterval = 5f;
    public float healthSpawnInterval = 5f;

    public GameObject[] coins;
    public GameObject[] buffs;
    public GameObject[] debuffs;
    public GameObject health;
    public GameObject boot;

        
    //public bool gameOver = false;

    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", coinSpawnInterval, coinSpawnInterval);
        InvokeRepeating("SpawnProjectiles", projectileSpawnInterval, projectileSpawnInterval);
        InvokeRepeating("SpawnBuffs", buffSpawnInterval, buffSpawnInterval);
        InvokeRepeating("SpawnDebuffs", debuffSpawnInterval, debuffSpawnInterval);
        InvokeRepeating("SpawnHealth", healthSpawnInterval, healthSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void SpawnCoins()
    {
        float randomX = Random.Range(xSpawnAreaLeftBound, xSpawnAreaRightBound);
        float randomZ = Random.Range(zSpawnAreaBotBound, zSpawnAreaTopBound);

        int randomIndex = Random.Range(0, coins.Length);

        Vector3 coinPos = new Vector3(randomX, ySpawnCoinsHeight, randomZ);

        Instantiate(coins[randomIndex], coinPos, coins[randomIndex].gameObject.transform.rotation);
    }

    private void SpawnProjectiles()
    {
        float randomX = Random.Range(xSpawnAreaLeftBound, xSpawnAreaRightBound);
        float randomZ = Random.Range(zSpawnAreaBotBound, zSpawnAreaTopBound);

        if (currentTime < secondPhaseStartTime)
        {

            Vector3 bootPos = new Vector3(xProjectileSpawnRange, ySpawnProjectileHeight, randomZ);

            projectileDirection = 1;

            Instantiate(boot, bootPos, boot.gameObject.transform.rotation);
        }

        else if(currentTime < thirdPhaseStartTime)
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
                //    Vector3 bootPos4 = new Vector3(randomX, ySpawnProjectileHeight, zProjectileSpawnRange);

                //    Instantiate(boot, bootPos4, boot.gameObject.transform.rotation);
                //    break;
                case 3:
                    projectileDirection = 3;
                    Vector3 bootPos3 = new Vector3(randomX, ySpawnProjectileHeight, -zProjectileSpawnRange);

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

    void SpawnBuffs()
    {
        float randomX = Random.Range(xSpawnAreaLeftBound, xSpawnAreaRightBound);
        float randomZ = Random.Range(zSpawnAreaBotBound, zSpawnAreaTopBound);

        int randomIndex = Random.Range(0, buffs.Length);

        Vector3 buffPos = new Vector3(randomX, ySpawnBuffsHeight, randomZ);

        Instantiate(buffs[randomIndex], buffPos, buffs[randomIndex].gameObject.transform.rotation);
    }

    void SpawnDebuffs()
    {
        float randomX = Random.Range(xSpawnAreaLeftBound, xSpawnAreaRightBound);
        float randomZ = Random.Range(zSpawnAreaBotBound, zSpawnAreaTopBound);

        int randomIndex = Random.Range(0, debuffs.Length);

        Vector3 debuffPos = new Vector3(randomX, ySpawnBuffsHeight, randomZ);

        Instantiate(debuffs[randomIndex], debuffPos, debuffs[randomIndex].gameObject.transform.rotation);
    }

    void SpawnHealth()
    {
        float randomX = Random.Range(xSpawnAreaLeftBound, xSpawnAreaRightBound);
        float randomZ = Random.Range(zSpawnAreaBotBound, zSpawnAreaTopBound);

        Vector3 healPos = new Vector3(randomX, ySpawnBuffsHeight, randomZ);

        Instantiate(health, healPos, health.gameObject.transform.rotation);
    }

    void Timer()
    {
        currentTime += Time.deltaTime;
    }
}
