using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] 
    float maxX;

    [SerializeField]
    float spawnInterval;

    public GameObject[] Boulder;

    public static Spawner instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
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
        int rand = Random.Range(0, Boulder.Length);

        float randomX = Random.Range(-maxX, maxX);

        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(Boulder[rand], randomPos, transform.rotation);
    }

 
    IEnumerator SpawnBoulders()
    {
        yield return new WaitForSeconds(2f);

        while(true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine("SpawnBoulders");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnBoulders");
    }

}
