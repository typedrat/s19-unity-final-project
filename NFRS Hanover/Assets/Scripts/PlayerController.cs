﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerBody = gameObject.GetComponent<Rigidbody2D>();
        if(gameObject.transform.position.y <= -4)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -4, gameObject.transform.position.z);
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
        }

        if(gameObject.transform.position.y >= 11)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 11, gameObject.transform.position.z);
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //this.GetComponent<Health>().TakeDamage(10);
        Debug.Log("OnCollisionEnter2D");
    }
}
