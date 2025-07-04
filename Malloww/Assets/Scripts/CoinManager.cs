using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coin;
    public static CoinManager instance;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Load coin khi vào game
        coin = PlayerPrefs.GetInt("Coin", 0);
        Debug.Log("Coin hiện tại: " + coin);
        UpdateCoinUI();
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        SaveCoin();
        Debug.Log("Đã nhận coin, tổng coin: " + coin);
        UpdateCoinUI();
    }

    public int GetCoin()
    {
        return coin;
    }

    public void SpendCoin(int amount)
    {
        if (coin >= amount)
        {
            coin -= amount;
            SaveCoin();
            Debug.Log("Đã tiêu coin, còn lại: " + coin);
            UpdateCoinUI();
        }
        else
        {
            Debug.Log("Không đủ coin để mua!");
        }
    }

    private void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.Save();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = coin.ToString();
    }
}
