using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject toHide;
    public GameObject toShow;

    public void doButton()
    {
        toShow.SetActive(true);
        //TODO animation or something
        toHide.SetActive(false);
    }
}
