using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public float scaleMultiplier = 1.5f; // 變大倍數
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 確認碰撞對象是否是玩家
        if (other.CompareTag("Player"))
        {
            // 獲取玩家的父物件
            Transform playerParent = other.transform.root;

            // 讓玩家的父物件大小變為1.5倍
            playerParent.localScale *= scaleMultiplier;

            // 撞擊後銷毀蘑菇
            Destroy(gameObject);
        }
    }
}
