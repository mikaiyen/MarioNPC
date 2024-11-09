using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 確認碰撞對象是否是玩家
        if (other.CompareTag("Body"))
        {
            BuffHandler buffHandler = other.transform.root.GetComponentInChildren<BuffHandler>();
            if (buffHandler != null)
            {
                Debug.Log("Player got the mushroom!");
                buffHandler.ApplyMushroomBuff();
                
                // Destroy the mushroom after applying the buff
                Destroy(gameObject);
            }
        }
    }

}
