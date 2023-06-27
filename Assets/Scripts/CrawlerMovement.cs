using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerMovement : MonoBehaviour
{
    public Transform[] waypoints; // References of moving points
    public float moveSpeed = 5f; // movement speed
    private int currentWaypointIndex = 0; // current destination index
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  // Move towards the target point
    Vector3 targetPosition = waypoints[currentWaypointIndex].position;
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    // Proceed to the next target point when the target point is reached
    if (transform.position == targetPosition)
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0; // Back to top when end point is reached
        }

        // Set character's rotation when moving to new target point
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
         // Reset Y direction

            
            Quaternion targetRotation = Quaternion.LookRotation(-direction.normalized,Vector3.up)* Quaternion.Euler(0f, 180f, 0f);
            Vector3 eulerAngles = targetRotation.eulerAngles;
            eulerAngles.y += 90f;
            targetRotation = Quaternion.Euler(eulerAngles);
            transform.rotation = targetRotation;
    }
    }
}
