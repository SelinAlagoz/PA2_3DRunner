using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

     private Animator animator;
    //public Animator crawlerAnimator;
    //public Animator crawlerwalkingAnimator;
    //public float vurmaMesafesi = 5f;


    public bool CanSeePlayers;
    void Start()
    {
        //crawlerAnimator = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
        //crawlerAnimator = GameObject.FindGameObjectWithTag("MonsterWalk").GetComponent<Animator>();
        animator = GetComponent<Animator>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.01f;
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        while (true) 
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeCheck.Length !=0)
        {
            Transform target = rangeCheck[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2 )
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    CanSeePlayers = true;
                    //crawlerAnimator.SetTrigger("Attack");
                    animator.SetTrigger("Attack");
                    /*if (distanceToTarget <= vurmaMesafesi)
                    {
                        crawlerwalkingAnimator.SetTrigger("Attack");
            
                        crawlerwalkingAnimator.SetTrigger("DidSee");
                    }
                    else
                    {
                        crawlerwalkingAnimator.SetTrigger("Crawler");
                        crawlerAnimator.SetTrigger("NotAttack");
                    }*/
                }
                    
                    
                    else CanSeePlayers = false;
                    animator.SetTrigger("NotAttack");
            }
            else 
               CanSeePlayers = false;
               animator.SetTrigger("NotAttack");
        }
        else if(CanSeePlayers)
            CanSeePlayers = false;
            animator.SetTrigger("NotAttack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
