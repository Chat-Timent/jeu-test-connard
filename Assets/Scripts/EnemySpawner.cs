using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform player;
    private float spawnRadius = 30;
    private float spawnDistance = 25;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float enemiesPerSpawn = 3;
    private Vector2 randomPoint;
    private Vector3 spawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPoint()
    {
        randomPoint = Random.insideUnitCircle * spawnRadius;
        spawnPos.x = randomPoint.x;
        spawnPos.y = 0;
        spawnPos.z = randomPoint.y;

        if (Vector3.Distance(spawnPos, Vector3.zero) <= spawnDistance)
        {
            return GenerateSpawnPoint();
        }

        return spawnPos;
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Vector3 mobSpawnPos = GenerateSpawnPoint();

                GameObject mob = Instantiate(enemyPrefab, mobSpawnPos + player.position, Quaternion.identity);
                EnemyAI enemyAI = mob.GetComponent<EnemyAI>();
                enemyAI.player = player;

                EnemyHealth enemyHealth = mob.GetComponent<EnemyHealth>();
                enemyHealth.playerStats = player.GetComponent<PlayerStats>();
            }
        }
    }
}
