using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("Object and Component References")]
    [Space(3)]
    [SerializeField] GameObject gameUIPanel;

    [Space(10)]
    [SerializeField] TextMeshProUGUI yearCountText;

    [Space(10)]
    [SerializeField] GameObject optionsUIPanel;
    [SerializeField] Animator optionsMenuAnimator;

    [Header("Class References")]
    [Space(3)]
    [SerializeField] YearManager yearManager;

    void Start()
    {
        yearManager.endOfYear.AddListener(UpdateYearText);
    }

    public void OpenUpgradeMenu()
    {
        Debug.Log("upgrade menu opened");
    }

    public void OpenStructuresMenu()
    {
        Debug.Log("structures menu opened");
    }

    public void OpenOptionsMenu()
    {
        optionsUIPanel.SetActive(true);
        gameUIPanel.SetActive(false);

        optionsMenuAnimator.SetTrigger("openMenu");
    }

    void UpdateYearText(int year)
    {
        yearCountText.text = "Year: " + yearManager.yearCount;
    }
}
