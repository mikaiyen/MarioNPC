using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaPatrol : MonoBehaviour
{
    public Transform pointA;        // 起點位置
    public Transform pointB;        // 終點位置
    public float speed = 3f;        // 移動速度
    public float swayAmplitude = 45f;         // 左右搖擺的幅度（角度）
    public float swayFrequency = 5f;          // 左右搖擺的頻率
    private float swayTimer = 0f;             // 搖擺計時器


    private Vector3 targetPosition; // 目標位置

    void Start()
    {
        // 設置初始目標為點 A
        targetPosition = pointA.position;
    }

    void Update()
    {
        Wander();
    }


    void Wander()
    {
        // 向遊蕩目標移動
        MoveTowards(targetPosition, speed);

        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;  // 到達目標後設置新的遊蕩目標
        }
    }

    void MoveTowards(Vector3 target, float speed)
    {
        // 讓怪物移動到目標並朝向移動的方向
        Vector3 direction = (target - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        // 設置旋轉，讓怪物的 Z 軸朝向移動的方向
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);

            // 左右搖晃效果
            swayTimer += Time.deltaTime * swayFrequency;
            float swayAngle = Mathf.Sin(swayTimer) * swayAmplitude;
            targetRotation *= Quaternion.Euler(0, 0, swayAngle);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
