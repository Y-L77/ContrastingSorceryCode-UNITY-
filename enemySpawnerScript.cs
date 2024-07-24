using System.Collections;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy
    public int maxEnemies = 4; // Maximum number of enemies allowed
    public float spawnInterval = 20f; // Interval between enemy spawns (in seconds)
    public float lastSpawnTime; // Time when the last enemy was spawned
    public float spawnDistance = 10f; // Distance check for existing enemies
    public string mobName;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval && CountEnemiesByName(mobName) < maxEnemies && !IsEnemyWithinDistance(mobName, spawnDistance))
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnEnemy()
    {
        // Spawn the enemy at the position of the spawner
        Vector3 spawnPosition = transform.position; // Use the spawner's position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private int CountEnemiesByName(string enemyName)
    {
        GameObject[] enemies = GameObject.FindObjectsOfType<GameObject>();
        int count = 0;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.name == enemyName)
            {
                count++;
            }
        }

        return count;
    }

    private bool IsEnemyWithinDistance(string enemyName, float distance)
    {
        GameObject[] enemies = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (enemy.name == enemyName && Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                return true; // Found an enemy within the specified distance
            }
        }

        return false; // No enemies found within the specified distance
    }
}
