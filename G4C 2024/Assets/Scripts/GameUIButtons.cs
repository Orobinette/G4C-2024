using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIButtons : MonoBehaviour
{
    [SerializeField] GameObject gameUIPanel;
    [SerializeField] GameObject optionsUIPanel;

    [SerializeField] Animator optionsMenuAnimator;

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
}
