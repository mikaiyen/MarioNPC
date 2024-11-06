using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaCollide : MonoBehaviour
{
    public float bounceForce = 10f;           // 彈跳的力度
    public float lifetime = 2f;
    private Vector3 originalScale; // 原始縮放比例
    private void Start()
    {
        // 記錄 Goomba 原始的縮放比例
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否與玩家碰撞
        if (other.CompareTag("Body"))
        {
            // 碰到 Capsule Collider，顯示 damage 訊息
            Debug.Log("Goomba 碰到玩家");
        }


        if (other.CompareTag("Feet"))
        {
            // 碰到 Box Collider，顯示 Goomba 損血訊息
            Debug.Log("Goomba 被踩");

            // 給玩家父物件一個向上的彈跳力
            Rigidbody playerRigidbody = other.GetComponentInParent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }

            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.3f, originalScale.z);

            Destroy(gameObject, lifetime);
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     // 檢查是否碰到 Player
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         // 檢查碰到的是哪個 Collider
    //         foreach (ContactPoint contact in collision.contacts)
    //         {
    //             Collider hitCollider = contact.thisCollider;

    //             if (hitCollider is CapsuleCollider)
    //             {
    //                 // Player 的 Capsule Collider
    //                 Debug.Log("Goomba 碰到玩家");
    //             }
    //             else if (hitCollider is BoxCollider)
    //             {
    //                 // Player 的 feet 下的 Box Collider
    //                 Debug.Log("Goomba 被踩");
    //             }
    //         }
    //     }
    // }
}
