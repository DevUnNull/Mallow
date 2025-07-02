using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Nếu ra khỏi màn hình thì huỷ
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
