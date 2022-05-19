using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    public GameObject deathParticlesPrefab;
    public float health = 100f;
    public float maxHealth = 100f;
    public float deathHeight = -15f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cone"))
        {
            ConeScript hitScript = other.gameObject.GetComponent<ConeScript>();
            health -= hitScript.damage;

            Vector3 bounceVector = (transform.position - other.gameObject.transform.position) * hitScript.bounceForce;
            playerRigidbody2D.velocity = Vector2.zero; //reset velocity so you always bounce the same amount
            playerRigidbody2D.AddForce(new Vector2(bounceVector.x, bounceVector.y));
        }
    }

    void Update()
    {
        if (transform.position.y <= deathHeight) //if you go too far down u die
        {
            health -= Time.deltaTime * 100;
        }
        
        if (health <= 0)
        {
            GameObject tempP = Instantiate(deathParticlesPrefab, gameObject.transform.position,
                gameObject.transform.rotation);

            Destroy(tempP, 5);
            gameObject.SetActive(false); //disable self
        }
    }
}
