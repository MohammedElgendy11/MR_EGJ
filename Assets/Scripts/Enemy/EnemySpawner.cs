using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("Spawn Locations")]
    public Transform[] spawnPositions; 
    public float spawnRate = 2f;

    void OnEnable()
    {
        KeypadController.OnPuzzleCompleted += StartSpawning;
    }

    void OnDisable()
    {
        KeypadController.OnPuzzleCompleted -= StartSpawning;
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void SpawnEnemy()
    {
        if (spawnPositions.Length == 0)
        {
            Debug.LogWarning("No spawn positions assigned");
            return;
        }
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Transform selectedPoint = spawnPositions[randomIndex];
        Instantiate(enemyPrefab, selectedPoint.position, selectedPoint.rotation);
    }
}