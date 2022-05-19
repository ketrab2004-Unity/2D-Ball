using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    public GameObject levelPanelPrefab;
    public GameObject levels;
    public GameObject levelsUI;
    public GameObject levelsMenu;
    public GameObject playerRespawn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int amountOfLevelPanels = 0;
        foreach (Transform childTransform in levels.transform)
        {
            GameObject child = childTransform.gameObject;
            LevelInfo levelInfo = child.GetComponent<LevelInfo>();

            if (levelInfo.levelOrder >= 0) //isn't menu background level
            {
                amountOfLevelPanels++;
                
                GameObject levelPanel = Instantiate(levelPanelPrefab, levelsUI.transform);
                LevelPanelControl levelPanelControl = levelPanel.GetComponent<LevelPanelControl>();

                levelPanelControl.respawnPlayer = playerRespawn;
                levelPanelControl.level = child;
                levelPanelControl.levels = levels;
                levelPanelControl.levelMenu = levelsMenu;
            }
        }
        
        //TODO increase size of levels ui to fit all levelpanels
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
