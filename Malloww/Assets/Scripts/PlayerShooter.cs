using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    private bool isShooting;
    private float timer;
    public float shootingInterval = 0.2f;
    private float cooldown;

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
