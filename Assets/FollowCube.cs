using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    //Simple Script to keep gimbal on the object
    public GameObject Camera;
    public GameObject Cube;

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            this.transform.position = Cube.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Camera.transform.rotation,999);
        }
        
    }
}
