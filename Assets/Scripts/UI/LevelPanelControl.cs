using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelControl : MonoBehaviour
{
    public GameObject respawnPlayer;
    private RespawnPlayer respawnPlayerScript;
    public GameObject level;
    public GameObject levels;
    private LevelInfo levelInfo;
    public GameObject icon;
    public GameObject title;
    public GameObject description;
    public GameObject playButtonText;
    public GameObject levelMenu;

    void Start()
    {
        respawnPlayerScript = respawnPlayer.GetComponent<RespawnPlayer>();

        levelInfo = level.GetComponent<LevelInfo>();
        RefreshPanel();
    }

    public void RefreshPanel()
    {
        icon.GetComponent<Image>().overrideSprite = levelInfo.levelIcon;

        title.GetComponent<Text>().text = levelInfo.levelName;
        description.GetComponent<Text>().text = levelInfo.levelDescription;

        if (respawnPlayerScript.reachedLevel >= levelInfo.levelOrder)
        {
            playButtonText.GetComponent<Text>().text = "Play";
        }
        else
        {
            playButtonText.GetComponent<Text>().text = "Locked";
        }
    }

    public void PlayLevelButton()
    {
        if (respawnPlayerScript.reachedLevel >= levelInfo.levelOrder)
        {
            foreach (Transform child in levels.transform)
            {
                GameObject curLevel = child.gameObject;
                if (curLevel == level)
                {
                    curLevel.SetActive(true);
                }
                else
                {
                    curLevel.SetActive(false);
                }
            }

            respawnPlayerScript.currentLevel = levelInfo.levelOrder; //set currentlevel
            respawnPlayerScript.currentCheckpoint = -1; //reset checkpoint
            
            respawnPlayerScript.CreatePlayer();
            
            levelMenu.SetActive(false);
        }
    }
}
