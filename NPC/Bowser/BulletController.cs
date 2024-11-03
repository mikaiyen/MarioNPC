using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;              // 發射物的追蹤速度
    public float lifetime = 5f;           // 發射物的存活時間
    // private Transform target;             // 追蹤目標
    private Vector3 TargetPosition; // 玩家初始位置
    private Vector3 direction;

    void Start()
    {
        // 自動找到玩家（確保玩家有 "Player" 標籤）
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            TargetPosition = player.transform.position;
            direction = (TargetPosition - transform.position).normalized;
            transform.LookAt(TargetPosition);
        }

        // 在指定時間後銷毀發射物
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (TargetPosition == null) return;
        flying();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否與玩家碰撞
        if (other.CompareTag("Player"))
        {
            Debug.Log("player 被擊中");
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void flying(){
        // 計算方向並移動發射物
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, TargetPosition) < 0.2f)
        {
            Destroy(gameObject);
        }
    }
}
