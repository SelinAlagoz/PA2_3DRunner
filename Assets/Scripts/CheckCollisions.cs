using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for reachng to text mesh pro 

public class CheckCollisions : MonoBehaviour
{

  public int score;
  public TextMeshProUGUI BookText;
  public PlayerController playerController; //We take references so that we can access the speed of the character.
private void OnTriggerEnter(Collider other)
{
 if(other.CompareTag("Book"))
 {
      AddBook();
      other.gameObject.SetActive(false); 
      //Destroy(other.gameObject);
      //Debug.Log(other.gameObject.name);
 }
    else if (other.CompareTag("End"))
    {
        Debug.Log("Congrats... !");
        playerController.runningSpeed = 0;
    }
}

private void OnCollisionEnter(Collision collision) {
  if(collision.gameObject.CompareTag("Collision"))
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
