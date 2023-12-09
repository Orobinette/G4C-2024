using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class FlexibleGridLayout : LayoutGroup
{
    public enum FitType
    {
        Uniform,
        PrioritizeWidth,
        PrioritizeHeight,
        FixedRows,
        FixedColumns
    }
    public FitType fitType;

    public int rows;
    public int columns;

    public Vector2 spacing;
    private Vector2 cellSize;
    private Vector2 anchorPoint;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        //Grid dimensions
        float sqrt = Mathf.Sqrt(transform.childCount);
        switch(fitType)
        {
            case FitType.Uniform:
                columns = Mathf.CeilToInt(sqrt);
                break;

            case FitType.PrioritizeWidth:
                columns = Mathf.CeilToInt(sqrt);
                break;

            case FitType.PrioritizeHeight:
                columns = Mathf.CeilToInt(rectChildren.Count / (float) Mathf.CeilToInt(sqrt));
                break;

            case FitType.FixedRows:
                columns = Mathf.CeilToInt(rectChildren.Count / (float) rows);
                break; 
        }

        //Cell dimensions
        float parentWidth = rectTransform.rect.width;
        cellSize.x = (parentWidth - (padding.left + padding.right) - spacing.x * (columns - 1)) / (float) columns;
    }
    public override void CalculateLayoutInputVertical()
    {
        //Grid dimensions
        float sqrt = Mathf.Sqrt(transform.childCount);
        switch(fitType)
        {
            case FitType.Uniform:
                rows = Mathf.CeilToInt(sqrt);   
                break;

            case FitType.PrioritizeWidth:
                rows = Mathf.CeilToInt(rectChildren.Count / (float) Mathf.CeilToInt(sqrt));
                break;

            case FitType.PrioritizeHeight:
                rows = Mathf.CeilToInt(sqrt);
                break;

            case FitType.FixedColumns:
                rows = Mathf.CeilToInt(rectChildren.Count / (float) columns);
                break;  
        }

        float parentHeight = rectTransform.rect.height;
        cellSize.y = (parentHeight - (padding.top + padding.bottom) - spacing.y * (rows - 1)) / (float) rows;
    }

    public override void SetLayoutHorizontal()
    {
        int columnCount = 0;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            var tile = rectChildren[i];

            columnCount = i % columns;

            float xPos = ((cellSize.x + spacing.x) * columnCount + padding.left);
            SetChildAlongAxis(tile, 0, xPos, cellSize.x);
        }
    }

    public override void SetLayoutVertical()
    {
        int rowCount = 0;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            var tile = rectChildren[i];

            rowCount = i / columns;

            float yPos = ((cellSize.y + spacing.y) * rowCount + padding.top);
            SetChildAlongAxis(tile, 1, yPos, cellSize.y);
        }

    }
}