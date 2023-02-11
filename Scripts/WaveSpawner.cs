using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private Wave currentWave;
    private int currentWaveIndex;
    private GameObject player;
    private bool finishedSpawning;

    // Start is called before the first frame update
    void Start()
    {
        //timeBetweenWaves = Random.Range();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }
    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }
    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for(int i = 0; i <= currentWave.count; i++)
        {
            if(player == null)
            {
                break;
            }
            if(i == currentWave.count - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }
            Enemy RandomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];

            Transform RandomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(RandomEnemy, RandomSpot.position, RandomSpot.rotation);

            yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(finishedSpawning == true)
        {
            finishedSpawning = false;
            if(currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
        }
    }
}
