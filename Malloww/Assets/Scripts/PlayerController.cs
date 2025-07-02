using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isGravityFlipped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f; // trọng lực bình thường kéo xuống
    }

    void Update()
    {
        // Lật trọng lực khi nhấn chuột
        if (Input.GetMouseButtonDown(0))
        {
            isGravityFlipped = !isGravityFlipped;
            rb.gravityScale *= -1;

            // Lật ngược sprite (tùy chọn – cho vui)
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }
    }
}
