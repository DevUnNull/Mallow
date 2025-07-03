using UnityEngine;

public class ObstacleHeal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shooter"))
        {
            Destroy(other.gameObject);   // Xoá Shooter
            Destroy(this.gameObject);    // Xoá chính Obstacle
        }
    }
}
