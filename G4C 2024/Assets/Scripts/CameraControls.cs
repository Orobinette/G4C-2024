using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    bool drag;
    Vector3 difference;
    Vector3 origin;
    [SerializeField] Camera mainCamera;

    void LateUpdate()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Zoom();
        }

        if(Input.GetMouseButton(2))
        {
            difference = (mainCamera.ScreenToWorldPoint(Input.mousePosition)) - mainCamera.transform.position;
            if(!drag)
            {
                drag = true;
                origin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if(drag)
        {
            mainCamera.transform.position = origin - difference;
        }
    }

    void Zoom()
    {
        //Zoom out
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            mainCamera.orthographicSize++;
            
        }
        //Zoom in 
        else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            mainCamera.orthographicSize--;
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 1f, float.MaxValue);
        }
    }
}
