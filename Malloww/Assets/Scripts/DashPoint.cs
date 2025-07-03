using UnityEngine;

public class DashPoint : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.MinusPoint(pointValue);
            Destroy(gameObject); 
        }
    }
}
