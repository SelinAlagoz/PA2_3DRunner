using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for reachng to text mesh pro 

public class CheckCollisions : MonoBehaviour
{

  public int score;
  public TextMeshProUGUI BookText;
private void OnTriggerEnter(Collider other)
{
 if(other.CompareTag("Book"))
 {
   AddBook();
   other.gameObject.SetActive(false); 
    //Destroy(other.gameObject);
    //Debug.Log(other.gameObject.name);
 }
}

private void OnCollisionEnter(Collision collision) {
  if(collision.gameObject.CompareTag("Obstacle"))
  {
    Debug.Log("Touched Obstacle!");
  }
  
}
public void AddBook()
{
  score++;
  BookText.text = "Score: " + score.ToString();
}
}
