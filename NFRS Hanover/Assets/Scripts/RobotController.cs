using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private System.Random rnd;
    [SerializeField] private int seed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random(seed);
    }

    // Update is called once per frame
    void Update()
    {
        var animator = this.gameObject.GetComponent<Animator>();
        animator.SetFloat("Random", rnd.Next(0,12));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var health = collision.gameObject.GetComponentInChildren<Health>();
            health.TakeDamage(10);
        }
    }

    
}
