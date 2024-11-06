using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public float invincibleTime = 10f; // 無敵時間
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
        if (other.CompareTag("Body"))
        {
            //應該要去改變player的state
            Debug.Log("player get star!");
            // 撞擊後銷毀
            Destroy(gameObject);
        }
    }
}
