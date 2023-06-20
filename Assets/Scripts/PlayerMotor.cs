
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private const float LANE_DISTANCE = 3.5f;
    private const float TURN_SPEED = 0.05f;

    //Animation
    private Animator anim;

    //Movement
    private CharacterController controller;
    private float jumpForce = 6.5f;
    private float gravity = 12f;
    private float verticalVelocity;
    public float speed = 9f;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = right

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Gather inputs on which lane we should be
        if (MobileInput.Instance.SwipeLeft)
            MoveLane(false);

        if (MobileInput.Instance.SwipeRight)
            MoveLane(true);

        //Calculate where we should be
        Vector3 targetposition = transform.position.z * Vector3.forward;

        if (desiredLane == 0)
            targetposition += Vector3.left * LANE_DISTANCE;
        else if (desiredLane == 2)
            targetposition += Vector3.right * LANE_DISTANCE;

        //Calculate our move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetposition - transform.position).normalized.x * speed;

        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded", isGrounded); 

        //calculate Y
        if(isGrounded) // if grounded
        {
            verticalVelocity = -0.1f;


            if(MobileInput.Instance.SwipeUp)
            {
                //jump
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

            if(MobileInput.Instance.SwipeDown)
            {
                verticalVelocity -= jumpForce;
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        //Move the druides
        controller.Move(moveVector * Time.deltaTime);

        //Rotate the druides
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        }


      
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += goingRight ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(
            new Vector3(
                controller.bounds.center.x,
                (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,
                controller.bounds.center.z),
            Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);

        return Physics.Raycast(groundRay, 0.2f + 0.1f);
    }
}