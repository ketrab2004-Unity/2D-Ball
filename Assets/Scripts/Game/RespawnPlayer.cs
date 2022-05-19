using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject mainCamera;
    public GameObject playerPrefab;
    public GameObject deathScreenPanel;
    public Transform respawnLocation;
    public int currentLevel = -1;
    public int reachedLevel = 0;

    public int currentCheckpoint = -1;

    private bool isDead = false;
    private int lastLevel = -1;
    void Update()
    {
        if (isDead || !playerObject.activeSelf || playerObject == null)
        {
            if (!isDead) //wasnt dead before so just died
            {
                Animator animator = deathScreenPanel.GetComponent<Animator>();
                animator.SetBool("Dead", true);
            }

            isDead = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Animator animator = deathScreenPanel.GetComponent<Animator>();
                animator.SetBool("Dead", false);

                CreatePlayer(); 
            }
        }
    }


    void RespawnPlayerFunc()
    {
        playerObject.transform.position = respawnLocation.position;
        playerObject.transform.rotation = respawnLocation.rotation;
        
        //update camera following
        mainCamera.GetComponent<PlayerFollower>().playerTransform = playerObject.transform;
        
        //update player's respawn script
        PlayerCheckpointController playerCpC = playerObject.GetComponent<PlayerCheckpointController>();

        PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
        playerHealth.health = playerHealth.maxHealth;
        
        playerCpC.playerRespawnLocation = respawnLocation;
        playerCpC.playerRespawnScript = this;
            
        playerObject.SetActive(true);
    }
    
    public void CreatePlayer()
    {
        if (playerObject == null) //player is not in existence
        {
            GameObject player = Instantiate(playerPrefab, respawnLocation.position, respawnLocation.rotation);

            //update camera following
            mainCamera.GetComponent<PlayerFollower>().playerTransform = player.transform;

            playerObject = player;

            //update player's respawn script
            PlayerCheckpointController playerCpC = player.GetComponent<PlayerCheckpointController>();
            
            //reset health to standard
            PlayerHealth playerHealth = playerObject.GetComponent<PlayerHealth>();
            playerHealth.health = playerHealth.maxHealth;

            playerCpC.playerRespawnLocation = respawnLocation;
            playerCpC.playerRespawnScript = this;
        }else if(!playerObject.activeSelf) //player is disabled
        {
            RespawnPlayerFunc();
        }
        else //player is active
        {
            RespawnPlayerFunc();
        }

        //no longer dead
        isDead = false;
    }
}
