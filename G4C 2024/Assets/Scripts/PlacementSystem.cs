using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndicator;
    [SerializeField] GridInputManager gridInputManager;
    [SerializeField] Grid grid;

    void Update()
    {
        Vector3 mousePos = gridInputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        mouseIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
