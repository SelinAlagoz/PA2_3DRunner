using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //for reachng to text mesh pro 
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{

  public int score;
  //public int maxScore; you can change in editor for your win/lose score.
  public TextMeshProUGUI BookText;
  //public PlayerController playerController;  //We take references so that we can access the speed of the character.
  public PlayerMotor playerMotor;
  public GameManager gameManager;

  public Animator PlayerAnim;
  public GameObject Player;
  public GameObject RestartPanel;

  Vector3 initialPosition;
  private Quaternion initialRotation;
  private Rigidbody rb;
   private InGameRanking ig;
  public GameObject speedBoosterIcon;

  [SerializeField] private AudioSource win, lose, hurt, bookshelf, speedbooster;

  private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
        //PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        speedBoosterIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();
    }
private void OnTriggerEnter(Collider other)
{
 if(other.CompareTag("Book"))
 {
      AddBook();
      bookshelf.Play();
      other.gameObject.SetActive(false); 
       
 }
    else if (other.CompareTag("End"))
    {
        Debug.Log("Congrats... !");
        PlayerFinished();
        if (ig.namesTxt[2].text == "Player")
            {
                Debug.Log("Congrats!..");
                PlayerAnim.SetBool("Win",true);
                win.Play();
                
            }
            else
            {
                Debug.Log("You Lose!..");
                PlayerAnim.SetBool("Lose",true);
                lose.Play();
            }
        /* win for score
          if ( score >= maxScore)
          {
            Debug.Log("You Win!...");
          }
          else
          {
            Debug.Log("You Lose!...");
          } */
    }
    else if(other.CompareTag("SpeedBoost"))
    {
      playerMotor.speed = playerMotor.speed + 3f;
      speedbooster.Play();
      speedBoosterIcon.SetActive(true);
      StartCoroutine(SlowAfterAWhileCoroutine());
    }
}

void PlayerFinished() 
{
    playerMotor.speed = 0f;
    Transform cameraTransform = Camera.main.transform;
    Vector3 lookAtPosition = new Vector3(cameraTransform.position.x, transform.position.y, cameraTransform.position.z);
    transform.LookAt(lookAtPosition);
    RestartPanel.SetActive(true);
     GameManager.instance.isGameOver = true; //when we use it this way, we don't need to take a reference.
}

private void OnCollisionEnter(Collision collision) {
  if(collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Monster"))
  {
       Debug.Log("Touched Obstacle!");
       hurt.Play();
       //transform.position = PlayerStartPos;
       ResetCharacterPosition();
  }
  
}

public void RestartGame()
{
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
public void AddBook()
{
  score++;
  BookText.text = "Score: " + score.ToString();
}
private void ResetCharacterPosition()
{
    rb.isKinematic = true;
    transform.position = initialPosition;
    transform.rotation = initialRotation;
    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
    rb.isKinematic = false;
}

 private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        playerMotor.speed = playerMotor.speed - 3f;
        speedBoosterIcon.SetActive(false);
    }
}
