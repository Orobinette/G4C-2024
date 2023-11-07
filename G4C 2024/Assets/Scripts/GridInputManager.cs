using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInputManager : MonoBehaviour
{
    [SerializeField] Collider2D tileCollider;
    [SerializeField] Camera sceneCamera;

    Vector3 lastPosition;
    [SerializeField] LayerMask gridLayerMask;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Vector3 rayOrigin = sceneCamera.ScreenToWorldPoint(mousePos);
        RaycastHit2D ray = Physics2D.Raycast(origin: rayOrigin, direction: Vector2.zero, distance: 1000,layerMask: gridLayerMask);
        if(ray)
        {
            lastPosition = ray.point;
        }
        return lastPosition;
    }
}
