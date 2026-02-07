using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public float spawnRate = 2f;

    [Header("UI")]
    [SerializeField] private GameObject endPanel;

    private int aliveEnemies;

    void OnEnable()
    {
        KeypadController.OnPuzzleCompleted += StartSpawning;
        EnemyHealth.OnEnemyDied += OnEnemyKilled;
    }

    void OnDisable()
    {
        KeypadController.OnPuzzleCompleted -= StartSpawning;
        EnemyHealth.OnEnemyDied -= OnEnemyKilled;
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

    void SpawnEnemy()
    {
        Transform point = spawnPositions[Random.Range(0, spawnPositions.Length)];
        Instantiate(enemyPrefab, point.position, point.rotation);
        aliveEnemies++;
    }

    void OnEnemyKilled()
    {
        aliveEnemies--;

        if (aliveEnemies <= 0)
        {
            endPanel.SetActive(true);
        }
    }
}
