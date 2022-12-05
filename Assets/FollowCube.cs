using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Cube;

    //Script to keep Gimbal (or whatever this script is attached to) following the object and facing the camera.
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            this.transform.position = Cube.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Camera.transform.rotation,999);
        }
        
    }
}
