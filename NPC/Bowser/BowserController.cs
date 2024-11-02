using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserController : MonoBehaviour
{
    public GameObject projectilePrefab;   // 投擲的圓球預製件
    public float throwInterval = 3f;      // 投擲間隔時間
    public Transform Muzzle;

    private float timer;                  // 計時器

    void Start()
    {
        timer = throwInterval;  // 初始化計時器
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnProjectile();
            timer = throwInterval;  // 重置計時器
        }
    }

    void SpawnProjectile()
    {
        // 創建發射物
        Instantiate(projectilePrefab, Muzzle.position, Quaternion.identity);
    }

    // void ThrowProjectile()
    // {
    //     // 創建圓球並將其指向玩家位置
    //     GameObject projectile = Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
        
    //     // 計算投擲方向
    //     Vector3 direction = (player.position - muzzle.position).normalized;
        
    //     // 給圓球施加力，使其飛向玩家
    //     Rigidbody rb = projectile.GetComponent<Rigidbody>();
    //     if (rb != null)
    //     {
    //         rb.AddForce(direction * throwForce, ForceMode.Impulse);
    //     }
    //     Destroy(projectile, projectileLifetime);
    // }
}
