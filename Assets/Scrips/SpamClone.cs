using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpamClone : MonoBehaviour
{
    public GameObject objectToClone;
   
    public Transform spawnPoint;
    public float spawnRadius = 1f;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnClone();
        }
       
    }

    void SpawnClone()
    {
        if (objectToClone != null)
        {
            // Nếu spawnPoint không được gán, sử dụng vị trí của object này
            Vector3 basePosition = spawnPoint != null ? spawnPoint.position : transform.position;

            // Thêm tọa độ ngẫu nhiên trong khoảng spawnRadius
            Vector3 randomOffset = new Vector3(
                Random.Range(-spawnRadius, spawnRadius), // X ngẫu nhiên
                Random.Range(-spawnRadius, spawnRadius), // Y ngẫu nhiên
                Random.Range(-spawnRadius, spawnRadius)  // Z ngẫu nhiên
            );

            Vector3 spawnPosition = basePosition + randomOffset;

            // Tạo clone tại vị trí spawn ngẫu nhiên
            GameObject clone = Instantiate(objectToClone, spawnPosition, Quaternion.identity);

            // Đặt tên cho clone để dễ phân biệt
            clone.name = objectToClone.name + "_Clone";
        }
        else
        {
            Debug.LogWarning("ObjectToClone chưa được gán trong Inspector!");
        }
      
        
    }
}
