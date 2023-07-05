using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    
    public GameObject CoinsPrefab;
    private Vector3 spawnPos;

    private float startDelay = 2;
    public float repeatRate;
    private float startDelay2 = 4;
    public float repeatRate2;
    private float startDelay3 = 3;
    public float repeatRate3;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        InvokeRepeating("SpawnObstacle2", startDelay2, repeatRate2);
        InvokeRepeating("SpawnCoins", startDelay3, repeatRate3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab[Random.Range(0, 2)], obstaclePrefab[Random.Range(0,2)].transform.position, obstaclePrefab[Random.Range(0, 2)].transform.rotation);
        }
    }
    void SpawnObstacle2()
    {
        if (playerController.gameOver == false)
        {
          

            Instantiate(obstaclePrefab[Random.Range(0, 2)], obstaclePrefab[Random.Range(0, 2)].transform.position, obstaclePrefab[Random.Range(0, 2)].transform.rotation);
        }
    }
    void SpawnCoins()
    {
        if (playerController.gameOver == false)
        {


            Instantiate(CoinsPrefab, CoinsPrefab.transform.position, CoinsPrefab.transform.rotation);
        }
    }
}
