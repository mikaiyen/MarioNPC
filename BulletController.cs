using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;              // 發射物的追蹤速度
    public float lifetime = 5f;           // 發射物的存活時間
    private Transform target;             // 追蹤目標

    void Start()
    {
        // 自動找到玩家（確保玩家有 "Player" 標籤）
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }

        // 在指定時間後銷毀發射物
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (target == null) return;

        // 計算方向並移動發射物
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target);
    }
}
