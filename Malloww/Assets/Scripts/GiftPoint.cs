using UnityEngine;

public class GiftPoint : MonoBehaviour
{
    private string reward;

    // Hàm nhận reward từ ObstacleSpawner
    public void SetReward(string rewardName)
    {
        reward = rewardName;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🎁 Bạn nhận được: " + reward);

            if (RewardManager.instance != null)
                RewardManager.instance.UnlockReward(reward);
            

            Destroy(gameObject);
        }
    }
}
