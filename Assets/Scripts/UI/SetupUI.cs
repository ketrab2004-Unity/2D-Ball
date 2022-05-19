using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupUI : MonoBehaviour
{
    public GameObject[] toShow;
    public GameObject[] toHide;
    
    // Setup ui
    void Start()
    {
        foreach (var Object in toShow)
        {
            Object.SetActive(true);
        }

        foreach (var Object in toHide)
        {
            Object.SetActive(false);
        }
    }
}
