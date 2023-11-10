using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    void Start()
    {
        //add a listener for resource change event that calsl UpdateMenu()
    }

    void UpdateMenu()
    {
        /*
        -go through every unlocked item and call for a resource check
        -if resource check is true put in buildabld list
        -if resourece check is false put in non buildable list
        -sort lists by type
        -update ui
        */
    }

    void OnUpgradeChange()
    {
        //for each unlocked strucutre,check if the qualifications are met for it to be unlocked, if they are add it to the update list
        UpdateMenu();
    }
}
