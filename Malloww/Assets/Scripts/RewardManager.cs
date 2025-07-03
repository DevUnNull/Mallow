using UnityEngine;
using System.Collections.Generic;

public class RewardManager : MonoBehaviour
{
    public static RewardManager instance;

    public List<string> unlockedRewards = new List<string>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UnlockReward(string rewardName)
    {
        if (!unlockedRewards.Contains(rewardName))
        {
            unlockedRewards.Add(rewardName);
            Debug.Log("✅ Đã mở khoá phần thưởng: " + rewardName);
            // TODO: Hiển thị UI hoặc lưu vào PlayerPrefs...
        }
        else
        {
            Debug.Log("🔁 Phần thưởng đã có trước đó: " + rewardName);
        }
    }
}
