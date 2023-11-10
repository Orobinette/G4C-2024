using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject gameUIPanel;
    [SerializeField] GameObject optionsUIPanel;

    public void BackButton()
    {
        gameUIPanel.SetActive(true);
        optionsUIPanel.SetActive(false);
    }
    public void OpenSettingsMenu()
    {
        Debug.Log("Settings menu opened");
        //save?
        //open settings menu
    }
    public void QuitToMenu()
    {
        Debug.Log("There's no main menu, but if there was the game would quit to it");
        //save data?
        //load menu scene
    }
    public void MuteButton()
    {
        
    }
}
