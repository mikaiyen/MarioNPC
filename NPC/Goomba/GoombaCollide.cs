using UnityEngine;

public class GoombaCollide : MonoBehaviour
{
    public float bounceForce = 25f;         // 彈跳力
    public float knockForce = 10f;          // 推力
    public float lifetime = 2f;             // Goomba 存活時間

    private Vector3 originalScale;          // 原始縮放比例

    private void Start()
    {
        originalScale = transform.localScale; // 記錄 Goomba 原始縮放比例
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRigidbody = other.GetComponentInParent<Rigidbody>();
        
        // 檢查是否與玩家的 Body 碰撞
        if (other.CompareTag("Body") && playerRigidbody != null)
        {
            Debug.Log("Goomba 碰到玩家");

            // 計算推力方向並施加推力
            Vector3 knockbackDirection = (playerRigidbody.transform.position - transform.position).normalized;
            playerRigidbody.AddForce(knockbackDirection * knockForce, ForceMode.Impulse);
        }

        // 檢查是否與玩家的 Feet 碰撞
        else if (other.CompareTag("Feet") && playerRigidbody != null)
        {
            Debug.Log("Goomba 被踩");

            // 施加向上的彈跳力
            playerRigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            // 壓扁 Goomba 並設定銷毀計時
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.3f, originalScale.z);
            Destroy(gameObject, lifetime);
        }
    }
}
