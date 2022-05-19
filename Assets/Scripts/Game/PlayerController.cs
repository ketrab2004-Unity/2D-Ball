using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D PlayerRigidBody;
    public float RollTorque = 100f;
    public float JumpForce = 6f;
    public float fallMult = 1.75f;
    public float lowJumpMult = 1.5f;
    public LayerMask JumpLayers;

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        float roll = -Input.GetAxis("Horizontal");

        PlayerRigidBody.AddTorque( delta * roll * RollTorque);

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.OverlapArea(
                new Vector2(transform.position.x - .3f, transform.position.y - .5f),
                new Vector2(transform.position.x + .3f, transform.position.y - .52f), JumpLayers))
            {
                PlayerRigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate() //physics update
    {
        if (PlayerRigidBody.velocity.y < 0) //better jumping
        {
            PlayerRigidBody.gravityScale = fallMult;
        }else if (PlayerRigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            PlayerRigidBody.gravityScale = lowJumpMult;
        }else
        {
            PlayerRigidBody.gravityScale = 1f;
        }
    }
}
