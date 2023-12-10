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
    [Space(10)]
    public FitType fitType;

    public bool fitX;
    public bool fitY;

    [Space(10)]
    public int rows;
    public int columns;

    public Vector2 spacing;
    public Vector2 cellSize;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        //Grid dimensions
        float sqrt = Mathf.Sqrt(transform.childCount);
        switch(fitType)
        {
            case FitType.Uniform:
                columns = Mathf.CeilToInt(sqrt);
                fitX = true;
                break;

            case FitType.PrioritizeWidth:
                columns = Mathf.CeilToInt(sqrt);
                fitX = true;
                break;

            case FitType.PrioritizeHeight:
                columns = Mathf.CeilToInt(rectChildren.Count / (float) Mathf.CeilToInt(sqrt));
                fitX = true;
                break;

            case FitType.FixedRows:
                columns = Mathf.CeilToInt(rectChildren.Count / (float) rows);
                break; 
        }

        //Cell dimensions
        float parentWidth = rectTransform.rect.width;
        float stretchedWidth = (parentWidth - (padding.left + padding.right) - spacing.x * (columns - 1)) / (float) columns;
        cellSize.x = fitX ? stretchedWidth : cellSize.x;
    }
    public override void CalculateLayoutInputVertical()
    {
        //Grid dimensions
        float sqrt = Mathf.Sqrt(transform.childCount);
        switch(fitType)
        {
            case FitType.Uniform:
                rows = Mathf.CeilToInt(sqrt);   
                fitY = true;
                break;

            case FitType.PrioritizeWidth:
                rows = Mathf.CeilToInt(rectChildren.Count / (float) Mathf.CeilToInt(sqrt));
                fitY = true;
                break;

            case FitType.PrioritizeHeight:
                rows = Mathf.CeilToInt(sqrt);
                fitY = true;
                break;

            case FitType.FixedColumns:
                rows = Mathf.CeilToInt(rectChildren.Count / (float) columns);
                break;  
        }

        float parentHeight = rectTransform.rect.height;
        float stretchedHeight = (parentHeight - (padding.top + padding.bottom) - spacing.y * (rows - 1)) / (float) rows;
        cellSize.y = fitY ? stretchedHeight : cellSize.y;
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