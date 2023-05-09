using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform TargetToTrack; // variable which will hold the player obj

    [SerializeField] float DistanceAwayFromTarget = 3.8f; // cams distance away from player variable
    [SerializeField] float HeightOffset = 3f; // height variable of cam
    [SerializeField] float CamDelay = 0.025f; // delay of camera follow variable 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FollowPos = TargetToTrack.position - TargetToTrack.forward * DistanceAwayFromTarget; // temp vector3 variable holds the target the camera follows - the foward times by the distance away from the target
        FollowPos.y += HeightOffset; // updates the cameras height position
        transform.position += (FollowPos - transform.position) * CamDelay; // delay effect for the camera when corners are met
        transform.LookAt(TargetToTrack.transform);
    } 
}
