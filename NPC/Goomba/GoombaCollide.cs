using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 檢查是否碰到 Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // 檢查碰到的是哪個 Collider
            foreach (ContactPoint contact in collision.contacts)
            {
                Collider hitCollider = contact.thisCollider;

                if (hitCollider is CapsuleCollider)
                {
                    // Player 的 Capsule Collider
                    Debug.Log("Goomba 碰觸到玩家，造成 damage！");
                }
                else if (hitCollider.name == "feet" && hitCollider is BoxCollider)
                {
                    // Player 的 feet 下的 Box Collider
                    Debug.Log("Goomba 受到損傷！");
                }
            }
        }
    }
}
