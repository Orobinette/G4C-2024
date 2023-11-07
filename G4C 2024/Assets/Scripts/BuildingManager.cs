using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] GameObject testBuilding;
    GameObject selectedBuilding;

    [SerializeField] GameObject mouseIndicator;

    void Start()
    {
        selectedBuilding = testBuilding;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }

    void PlaceBuilding()
    {
        GameObject newBuilding = Instantiate(selectedBuilding, mouseIndicator.transform.position, Quaternion.identity);
    }
}
