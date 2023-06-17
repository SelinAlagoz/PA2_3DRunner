using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WalkingCrFieldOfView))]

public class WalkingCrFieldOfViewEditor : Editor
{
  

  private void OnSceneGUI()
  {
    WalkingCrFieldOfView walkingfov = (WalkingCrFieldOfView)target;

   

    //walkingcrawler
    Handles.color = Color.white;
    Handles.DrawWireArc(walkingfov.transform.position, Vector3.up, Vector3.forward, 360, walkingfov.radius);


    //walkingcrawler
    Vector3 viewAngle01 = DirectionFromAngle(walkingfov.transform.eulerAngles.y, -walkingfov.angle / 2);
    Vector3 viewAngle02 = DirectionFromAngle(walkingfov.transform.eulerAngles.y, walkingfov.angle / 2);


    //walkingcrawler
    Handles.color = Color.yellow;
    Handles.DrawLine(walkingfov.transform.position, walkingfov.transform.position + viewAngle01 * walkingfov.radius );
    Handles.DrawLine(walkingfov.transform.position, walkingfov.transform.position + viewAngle02 * walkingfov.radius );

    if(walkingfov.CanSeePlayers)
    {
        Handles.color = Color.green;
        Handles.DrawLine(walkingfov.transform.position, walkingfov.playerRef.transform.position);
    }
  }

  private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
  {
    angleInDegrees += eulerY + 45f;

    return new Vector3(-Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, -Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
  }
}
