using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("🎉 Điểm: " + score);
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    public void MinusPoint(int amount)
    {
        score -= amount;
        Debug.Log("🎉 Điểm: " + score);
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
    
}
