using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class FlexibleGridLayout : LayoutGroup
{
    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }
    public FitType fitType;

    public int rows;
    public int columns;

    public Vector2 cellSize;
    public Vector2 spacing;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float sqrt = Mathf.Sqrt(transform.childCount);

        switch(fitType)
        {
            case FitType.Uniform:
                columns = Mathf.CeilToInt(sqrt);
                rows = Mathf.CeilToInt(sqrt);
                break;

            case FitType.Width:
                columns = Mathf.CeilToInt(sqrt);
                rows = Mathf.CeilToInt(rectChildren.Count / (float) columns);
                break;

            case FitType.Height:
                rows = Mathf.CeilToInt(sqrt);
                columns = Mathf.CeilToInt(rectChildren.Count / (float) rows);
                break;

            case FitType.FixedRows:
                columns = Mathf.CeilToInt(rectChildren.Count / (float) rows);
                break;
            
            case FitType.FixedColumns:
                rows = Mathf.CeilToInt(rectChildren.Count / (float) columns);
                break;  
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth - (padding.left + padding.right) - spacing.x * (columns - 1)) / (float) columns;
        float cellHeight = (parentHeight - (padding.top + padding.bottom) - spacing.y * (rows - 1)) / (float) rows;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;
    }
    public override void CalculateLayoutInputVertical(){}

    public override void SetLayoutHorizontal()
    {
        int columnCount = 0;
        int rowCount = 0;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var tile = rectChildren[i];

            var xPos = ((cellSize.x + spacing.x) * columnCount + padding.left);
            var yPos = ((cellSize.y + spacing.y) * rowCount + padding.top);

            SetChildAlongAxis(tile, 0, xPos, cellSize.x);
            SetChildAlongAxis(tile, 1, yPos, cellSize.y);
        }
    }

    public override void SetLayoutVertical(){}
}