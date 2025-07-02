using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // Nếu background ra khỏi màn hình thì lặp lại
        if (transform.position.x < -10f) // tuỳ theo chiều dài background
        {
            transform.position += new Vector3(7f, 0, 0); // loop lại từ bên phải
        }
    }
}
