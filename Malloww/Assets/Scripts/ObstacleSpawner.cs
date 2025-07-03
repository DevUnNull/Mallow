using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab & Tỷ lệ xuất hiện")]
    public GameObject[] obstaclePrefabs;
    public float[] spawnWeights;

    [Header("Thời gian spawn")]
    public float spawnInterval = 2f;
    private float timer;

    void Start()
    {
        if (spawnWeights.Length != obstaclePrefabs.Length)
        {
            Debug.LogWarning("⚠ spawnWeights và obstaclePrefabs không cùng độ dài!");
        }
    }

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
        int index = GetWeightedRandomIndex();
        Vector3 spawnPos = new Vector3(10f, Random.Range(-4.2f, 4.2f), 0f);

        // Spawn prefab
        GameObject spawned = Instantiate(obstaclePrefabs[index], spawnPos, Quaternion.identity);

        // Nếu prefab có GiftPoint, truyền rewardName là "Element {index}"
        GiftPoint gift = spawned.GetComponent<GiftPoint>();
        if (gift != null)
        {
            string rewardName = "Phần thưởng từ element " + index;
            gift.SetReward(rewardName);
            Debug.Log("🎁 Đã spawn Gift ở element " + index);
        }
    }


    int GetWeightedRandomIndex()
    {
        float totalWeight = 0f;
        foreach (float weight in spawnWeights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float cumulative = 0f;

        for (int i = 0; i < spawnWeights.Length; i++)
        {
            cumulative += spawnWeights[i];
            if (randomValue <= cumulative)
            {
                return i;
            }
        }

        return spawnWeights.Length - 1; // fallback
    }
}
