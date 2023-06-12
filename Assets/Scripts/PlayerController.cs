using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float runningSpeed; //For the forward movement of our character.
    // Start is called before the first frame update
    float touchXDelta = 0;
    float newX = 0;
    public float xSpeed;
    public float limitx;
    float limitxe = 2.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      SwipeCheck();
    }
    private void SwipeCheck()
    {
             

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
           //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
           touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width; // did this to keep our numbers in line with the screen.
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X"); //edit-> Project Manager -> Input Manager
        }
        else
        {
            touchXDelta = 0;
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx + limitxe, limitx); //our limit range
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime); 
        transform.position = newPosition;   //We put our new position into our existing one. 
    }
}
