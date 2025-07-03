using UnityEngine;

public class GiftPoint : MonoBehaviour
{
    public string rewardName;  // Đặt tên reward khi spawn

    public void SetRewardName(string name)
    {
        rewardName = name;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🎁 Player chạm vào quà: " + rewardName);
            RewardManager.instance?.UnlockReward(rewardName);
            Destroy(gameObject);
        }
    }
}
