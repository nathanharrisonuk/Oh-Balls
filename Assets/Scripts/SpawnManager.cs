using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    

    public GameObject enemyBall;
    public GameObject scoreBall;
    public GameObject healthBall;

    private GameManager gameManagerScript;

    private float xSpawnBound = 18.0f;
    private float ySpawnBound = 25.0f;
    private float zSpawnBound = 18.0f;

    private float enemyBallSpawnTime = 7.0f;
    private float scoreBallSpawnTime = 1.5f;
    private float healthBallSpawnTime = 25.0f;
    private float startDelay = 1.0f;
    //  bool active = true;


    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommenceSpawn(int difficulty)
    {
        
            InvokeRepeating("SpawnEnemyBall", startDelay, enemyBallSpawnTime / difficulty);
            InvokeRepeating("SpawnScoreBall", startDelay, scoreBallSpawnTime);
            InvokeRepeating("SpawnHealthBall", startDelay * 30, healthBallSpawnTime);
        
    }

 //   public void CancelSpawn()
   // {
    //    active = false;
   // }



    void SpawnEnemyBall()
    {
        if (gameManagerScript.isGameActive)

        {
            float randomDropPointX = Random.Range(-xSpawnBound, xSpawnBound);
            float randomDropPointZ = Random.Range(-zSpawnBound, zSpawnBound);

            Vector3 spawnPos = new Vector3(randomDropPointX, ySpawnBound, randomDropPointZ);

            Instantiate(enemyBall, spawnPos, enemyBall.gameObject.transform.rotation);
        }
        
    }




    void SpawnScoreBall()
    {
        if (gameManagerScript.isGameActive)

        {
            float randomDropPointX = Random.Range(-xSpawnBound, xSpawnBound);
            float randomDropPointZ = Random.Range(-zSpawnBound, zSpawnBound);

            Vector3 spawnPos = new Vector3(randomDropPointX, ySpawnBound, randomDropPointZ);

            Instantiate(scoreBall, spawnPos, scoreBall.gameObject.transform.rotation);
        }
    }




    void SpawnHealthBall()
    {
        if (gameManagerScript.isGameActive)
        {
            float randomDropPointX = Random.Range(-xSpawnBound, xSpawnBound);
            float randomDropPointZ = Random.Range(-zSpawnBound, zSpawnBound);

            Vector3 spawnPos = new Vector3(randomDropPointX, ySpawnBound, randomDropPointZ);

            Instantiate(healthBall, spawnPos, healthBall.gameObject.transform.rotation);
        }
    }
}
