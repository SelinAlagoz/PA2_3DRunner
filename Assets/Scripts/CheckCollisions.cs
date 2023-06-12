using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
private void OnTriggerEnter(Collider other)
{
 if(other.CompareTag("Book"))
 {
   Destroy(other.gameObject);
    //Debug.Log(other.gameObject.name);
 }
}
}
