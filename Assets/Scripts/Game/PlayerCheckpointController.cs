using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpointController : MonoBehaviour
{
    public RespawnPlayer playerRespawnScript;
    public Transform playerRespawnLocation;
    public string checkpointTag = "Checkpoint";
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(checkpointTag))
        {
            CheckpointSettings cpSettings = other.gameObject.GetComponent<CheckpointSettings>();
            if (cpSettings.checkpointNumber > playerRespawnScript.currentCheckpoint)
            {
                Animator animator = other.gameObject.GetComponent<Animator>();
                animator.SetBool("Activated", true);

                playerRespawnScript.currentCheckpoint = cpSettings.checkpointNumber;
                playerRespawnLocation.position = cpSettings.respawnTransform.position;

            }
        }
    }
}
