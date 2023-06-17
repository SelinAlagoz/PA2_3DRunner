using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerMovement : MonoBehaviour
{
    public Transform[] waypoints; // Hareket edilecek noktaların referansları
    public float moveSpeed = 5f; // Hareket hızı
    private int currentWaypointIndex = 0; // Şu anki hedef nokta index'i
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  // Hedef noktaya doğru hareket etme
    Vector3 targetPosition = waypoints[currentWaypointIndex].position;
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    // Hedef noktaya ulaşıldığında bir sonraki hedef noktaya geçme
    if (transform.position == targetPosition)
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0; // Son noktaya ulaşıldığında başa dön
        }

        // Yeni hedef noktaya geçildiğinde karakterin rotasyonunu belirle
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
         // Y yönünü sıfırla

            
            Quaternion targetRotation = Quaternion.LookRotation(-direction.normalized,Vector3.up)* Quaternion.Euler(0f, 180f, 0f);
            Vector3 eulerAngles = targetRotation.eulerAngles;
            eulerAngles.y += 90f;
            targetRotation = Quaternion.Euler(eulerAngles);
            transform.rotation = targetRotation;
    }
    }
}
