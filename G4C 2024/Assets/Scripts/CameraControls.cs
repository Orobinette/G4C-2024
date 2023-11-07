using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    ///Object References
    [SerializeField] Camera camera;

    //Data
    bool drag;
    Vector3 difference;
    Vector3 startingPosition;
    float zoomFactor = 0.2f;

    void Update()
    {
        MoveCamera();
        ZoomCamera();
    }   

    void MoveCamera()
    {
        if(Input.GetMouseButton(2))
        {
            difference = (camera.ScreenToWorldPoint(Input.mousePosition)) - camera.transform.position;
            if(drag == false)
            {
                drag = true;
                startingPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if(drag)
            camera.transform.position = startingPosition - difference;
    }

    void ZoomCamera()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0f) // zoom in 
        {
            camera.orthographicSize += zoomFactor;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0f) // zoom in 
        {
            camera.orthographicSize -= zoomFactor;
        }
    }
}
