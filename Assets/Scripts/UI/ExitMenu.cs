using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public GameObject exitMenuUI;
    public GameObject mainMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            exitMenuUI.SetActive(true);
            //TODO pause game
        }
    }

    public void UnpauseGame()
    {
        //TODO for return button
    }

    public void QuitButton()
    {
        //TODO unload levels
        
        mainMenu.SetActive(true);
        exitMenuUI.SetActive(false);
    }
}
