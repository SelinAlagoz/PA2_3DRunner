using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent OpponentAgent;
    public GameObject Target;
    public GameObject Agent;

    Vector3 OpponentStartPos;
    public GameObject speedBoosterIcon;
    private Animator AgentAnim;
    private PlayerMotor playerMotor;
    

    private InGameRanking ig;

    // Start is called before the first frame update
    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        AgentAnim = Agent.GetComponentInChildren<Animator>();
        OpponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();
        playerMotor = FindObjectOfType<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
         if (playerMotor.canMove)
        OpponentAgent.SetDestination(Target.transform.position);
        if(GameManager.instance.isGameOver)
        {
            OpponentAgent.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Monster"))
        {
            transform.position = OpponentStartPos;
            Debug.Log("AAAAAA");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            OpponentAgent.speed = OpponentAgent.speed + 3f;
            speedBoosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
        else if(other.CompareTag("End"))
        {
            OpponentAgent.speed = 0f;
            transform.Rotate(transform.rotation.x, 90, transform.rotation.z);
            
        if (ig.namesTxt[2].text == "Diaboli" || ig.namesTxt[2].text == "Necromancer")
          {
             AgentAnim.SetBool("Macerena",true);
          }
         else
          {
             AgentAnim.SetBool("Crying",true);
          }

        }
    }
    private IEnumerator SlowAfterAWhileCoroutine() {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed = OpponentAgent.speed - 3f;
        speedBoosterIcon.SetActive(false);
    }

}