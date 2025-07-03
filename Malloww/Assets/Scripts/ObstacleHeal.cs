using UnityEngine;

public class ObstacleHeal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shooter"))
        {
            Destroy(other.gameObject);   // Xo� Shooter
            Destroy(this.gameObject);    // Xo� ch�nh Obstacle
        }
    }
}
