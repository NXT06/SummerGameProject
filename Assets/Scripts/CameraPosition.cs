using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraPositionFar;
    public Transform cameraPositionClose;
    public Transform cameraPositionCamera; 
    public static bool cameraOn;
    // Update is called once per frame
    void Update()
    {
        EnterCameraMode();
        if (cameraOn)
        {
            transform.position = cameraPositionCamera.position;
        }
        else
        {
            if (Room.inRoom)
            {
                transform.position = cameraPositionClose.position;
            }
            else
            {
                transform.position = cameraPositionFar.position;
            }
        }

    }


    public void EnterCameraMode()
    {
        if (Input.GetMouseButton(1))
        {
            cameraOn = true; 
        
        }
        else
        {
            cameraOn = false; 
        }
    }
}
