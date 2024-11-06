using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserController : MonoBehaviour
{
    public GameObject projectilePrefab;   // 投擲的圓球預製件
    public float throwInterval = 3f;      // 投擲間隔時間
    public Transform Muzzle;
    public float health = 20;
    public Animator animator;

    private float timer;                  // 計時器
    private bool hasBeenHit;              // 用來檢查是否已經觸發過受擊

    void Start()
    {
        timer = throwInterval;            // 初始化計時器
        hasBeenHit = false;
    }

    void Update()
    {
        bool hurtPressed = Input.GetKeyDown("k");  //這行用來測試庫巴的受擊反應
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnProjectile();
            timer = throwInterval;  // 重置計時器
        }

        if (hurtPressed && !hasBeenHit)  //測試庫巴受擊反應
        {
            GetHit();
            hasBeenHit = true; 
        }
    }

    void SpawnProjectile()
    {
        // 創建發射物
        animator.SetBool("isThrow", true);
        Instantiate(projectilePrefab, Muzzle.position, Quaternion.identity);
        Invoke(nameof(ResetAnimation), 1f);
    }

    void GetHit()
    {
        animator.SetBool("isHurt", true);
        health--;
        Debug.Log("Bowser's health: " + health);
        HandleDeath();
        Invoke(nameof(ResetAnimation), 1f);
    }

    void HandleDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }

    void ResetAnimation()
    {
        animator.SetBool("isThrow", false);
        animator.SetBool("isHurt", false);
        hasBeenHit = false; // 重置 hasBeenHit，使得下一次可以再次受擊
    }
}