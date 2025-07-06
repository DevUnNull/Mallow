using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform player;
    public float followDistance = 1.5f;
    public float followSpeed = 5f;
    public float detectRadius = 5f;
    public float moveToCandySpeed = 7f;
    public float lifeTime = 10f;
    public float followOffsetX = 1.5f;  // khoảng cách theo X


    private Transform targetCandy;
    private bool isCollecting = false;
    private Vector3 originalPosition; // Vị trí cần quay về sau khi nhặt
    private PlayerCallPet manager; // để báo về manager

    public void SetManager(PlayerCallPet petManager)
    {
        manager = petManager;
    }
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            if (manager != null)
            {
                manager.RemovePet(this);  // Báo về manager xoá khỏi list
            }

            Destroy(gameObject);
            return;
        }

        // Nếu đang đi nhặt candy
        if (isCollecting)
        {
            if (targetCandy == null)
            {
                // Candy đã bị player lấy mất → quay về player
                Debug.Log("❌ Candy biến mất, pet quay về player.");
                ReturnToPlayer();
            }
            else
            {
                // Candy còn → tiếp tục di chuyển tới
                MoveToCandy();
            }
        }
        else
        {
            // Nếu không đang nhặt gì → tìm candy mới
            FindCandy();

            // Nếu chưa tìm thấy → follow player
            if (!isCollecting)
            {
                FollowPlayer();
            }
        }
    }


    void FollowPlayer()
    {
        if (!isCollecting)
        {
            // Mỗi pet có vị trí riêng theo followOffsetX
            Vector3 targetPos = player.position + Vector3.right * followOffsetX;
            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }


    void FindCandy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Candy"))
            {
                targetCandy = hit.transform;
                originalPosition = transform.position; // lưu vị trí hiện tại để quay về
                isCollecting = true;
                Debug.Log("🐾 Pet phát hiện candy: " + hit.name);
                break;
            }
        }
    }

    void MoveToCandy()
    {
        // Nếu candy đã bị huỷ giữa chừng
        if (targetCandy == null)
        {
            Debug.Log("❌ Candy bị player lấy mất rồi, pet quay về.");
            ReturnToPlayer();
            return;
        }

        // Nếu candy chưa bị huỷ → tiếp tục di chuyển đến
        transform.position = Vector3.MoveTowards(transform.position, targetCandy.position, moveToCandySpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetCandy.position);
        if (distance < 0.1f)
        {
            Debug.Log("🐾 Pet đã nhặt candy: " + targetCandy.name);
            ScoreManager.instance.AddScore(1);

            // Huỷ candy và reset trạng thái
            Destroy(targetCandy.gameObject);
            targetCandy = null;
            StartCoroutine(ReturnAfterDelay(0.2f));
        }
    }


    System.Collections.IEnumerator ReturnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (Vector3.Distance(transform.position, player.position + Vector3.right * followDistance) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position + Vector3.right * followDistance, followSpeed * Time.deltaTime);
            yield return null;
        }

        isCollecting = false;
    }

    void ReturnToPlayer()
    {
        isCollecting = false;
        targetCandy = null;
    }

    // Vẽ phạm vi quét candy
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
