using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform cameraPos;
    public static bool inRoom; 
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        inRoom = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        inRoom = false; 
        
    }
  
}
