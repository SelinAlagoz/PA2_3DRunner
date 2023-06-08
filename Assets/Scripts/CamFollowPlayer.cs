using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 10f;
    public Vector3 dist;
    public Transform lookTarget;
    public Transform cameraRotation;
    // Start is called before the first frame update
private void LateUpdate() {
    /*It is important to use LateUpdate, especially in situations such as camera tracking. 
    Because the Update function may not have updated the positions of other objects yet, and the camera is not required to be affected by these updates. 
    LateUpdate, on the other hand, can be used to correctly set the camera object's position and other properties, as it is called after other objects' updates.*/
   Vector3 dPos = cameraTarget.position + dist;
   Vector3 sPos = Vector3.Lerp(transform.position,dPos,sSpeed*Time.deltaTime);
   /*Vector3.Lerp (Linear Interpolation) is a method that provides a linear transition between two points.
    This method takes two Vector3 values ​​defined as the start point (start) and the target point (end) and produces a point between these two points.
    The resulting point moves linearly from the starting point to the target point. */
   Quaternion cRot = cameraRotation.rotation;
   transform.position = sPos;
   transform.LookAt(lookTarget.position);
   transform.rotation = cRot;
}
}
