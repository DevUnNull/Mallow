using UnityEngine;
using System.Collections.Generic;

public class RewardManager : MonoBehaviour
{
    public static RewardManager instance;

    [Header("Danh sách phần thưởng")]
    public List<RewardData> rewardList = new List<RewardData>();

    public PlayerShooter playerShooter;
    public CoinManager coinManager;
    // Có thể thêm các thành phần khác như HealManager, ShieldManager...

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UnlockReward(string rewardName)
    {
        RewardType foundReward = RewardType.None;

        // Tìm trong danh sách reward
        foreach (var rewardData in rewardList)
        {
            if (rewardData.rewardName == rewardName)
            {
                foundReward = rewardData.rewardType;
                break;
            }
        }

        if (foundReward == RewardType.None)
        {
            Debug.LogWarning("⚠ Không tìm thấy phần thưởng tương ứng với: " + rewardName);
            return;
        }

        Debug.Log("✅ Nhận được reward: " + foundReward);

        // Thực hiện phần thưởng theo loại
        switch (foundReward)
        {
            case RewardType.BonusShoot:
                Debug.Log ("bannnn");
                playerShooter?.ActivateShooting(2f);
                break;

            case RewardType.Heal:
                Debug.Log("🩹 Heal player (chưa triển khai).");
                break;

            case RewardType.Shield:
                Debug.Log("🛡️ Shield player (chưa triển khai).");
                break;
            case RewardType.Coin:
                CoinManager.instance.AddCoin(2);
                Debug.Log("duoc nha 2 coin");
                break;
        }
    }
}
