using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;    // Prefab viên đạn sẽ được tạo ra
    public Transform shootPoint;       // Vị trí bắn đạn (thường là 1 empty object trước Player)

    private bool isShooting;           // Kiểm tra xem Player có đang bắn không
    private float timer;               // Thời gian còn lại để bắn
    public float shootingInterval = 0.2f;  // Thời gian giữa các lần bắn (0.2 giây)
    private float cooldown;            // Đếm ngược để bắn tiếp

    void Update()
    {
        if (!isShooting) return;

        timer -= Time.deltaTime;
        cooldown -= Time.deltaTime;

        if (cooldown <= 0f)
        {
            Shoot();
            cooldown = shootingInterval;
        }

        if (timer <= 0f)
        {
            isShooting = false;
        }
    }

    public void ActivateShooting(float duration)
    {
        isShooting = true;
        timer = duration;
        cooldown = 0f;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        Debug.Log("💥 Player bắn đạn!");
    }
}
