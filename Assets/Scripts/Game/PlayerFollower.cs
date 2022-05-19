using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform playerTransform;
    public float dampTime = .15f;
    private Vector3 v3Zero = Vector3.zero;

    private Vector3 lastPos = Vector3.zero;
    void Update()
    {
        Vector3 destination;
        if (playerTransform != null && !playerTransform.Equals(null))
        {
            destination = playerTransform.position;
            destination.z = -10;
            lastPos = destination;
        }
        else
        {
            destination = lastPos;
        }

        transform.position = Vector3.SmoothDamp(transform.position, destination,
            ref v3Zero, dampTime);
    }
}
