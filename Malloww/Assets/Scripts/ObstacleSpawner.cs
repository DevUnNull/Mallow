using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(10f, Random.Range(-4.2f, 4.2f), 0f); // vị trí phải màn hình
        Instantiate(obstaclePrefabs[index], spawnPos, Quaternion.identity);
    }
}
