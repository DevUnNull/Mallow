using UnityEngine;
using UnityEngine.SceneManagement;

public class CandyPoint : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(pointValue);
            Destroy(gameObject); // xoá kẹo sau khi ăn
        }
    }
}
