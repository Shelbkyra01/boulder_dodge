using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour

{

    [SerializeField] 
    float maxX;

    [SerializeField]
    float spawnInterval;

    public GameObject[] Coin;

    public static CoinSpawner instance;

    
    
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int rand = Random.Range(0, Coin.Length);

        float randomX = Random.Range(-maxX, maxX);

        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(Coin[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(10f);

        while(true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine("SpawnCoins");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnCoins");
    }
}

