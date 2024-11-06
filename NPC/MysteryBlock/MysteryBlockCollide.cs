using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MysteryBlockCollide : MonoBehaviour
{
    public GameObject mushroomPrefab;  // 蘑菇
    public GameObject starPrefab;      // 星星
    public Transform spawnPoint;       // 生成點
    // Start is called before the first frame update
    private bool isUsed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Head"))
        {
            if(isUsed){
                return;
            }
            Debug.Log("mysterybox 啟動");
            // 隨機選擇生成蘑菇或星星
            GameObject selectedPrefab = Random.value > 0.5f ? mushroomPrefab : starPrefab;

            // 在 Mystery Block 上方生成選定的物件
            Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
            isUsed=true;
            
        }
    }
}
