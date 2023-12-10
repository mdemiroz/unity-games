using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject thingToFollow;
    // this thing's position should be the same as camera's position
    void LateUpdate()
    {
        // this object's transform's position is now equals to the camera's.
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
        // we added a new vector because the camera stays the same level with the car
        // and we can not see anything because camera is in z=0.
    }
}
