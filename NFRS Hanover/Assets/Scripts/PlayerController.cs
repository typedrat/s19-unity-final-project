using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Health Health;

    private void Start()
    {
        Health = gameObject.GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Hit laser!");
            Health.TakeDamage(10);
        }
    }
}
