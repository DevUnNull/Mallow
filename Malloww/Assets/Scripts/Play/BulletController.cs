using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    
}
