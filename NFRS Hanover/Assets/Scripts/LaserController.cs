using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private float TimeToFire = 1.5f, Timer = 0f;
    [SerializeField]
    private BoxCollider2D BeamCollider;

    private AudioSource Audio;
    private Animator Animator;
    private bool Enabled = false;

    void Start()
    {
        Audio = this.gameObject.GetComponent<AudioSource>();
        Animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled)
        {
            return;
        }

        Timer += Time.deltaTime;

        if (Timer >= TimeToFire)
        {
            Debug.Log("Firing laser");
            Timer = 0;
            Audio.Play();
            Animator.SetTrigger("Fire");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Got hit by laser.");
            var health = collision.gameObject.GetComponentInChildren<Health>();
            health.TakeDamage(10);
        }
    }

    public void EnableTrigger()
    {
        BeamCollider.enabled = true;
    }

    public void DisableTrigger()
    {
        BeamCollider.enabled = false;
    }

    private void OnBecameVisible()
    {
        Enabled = true;
    }

    private void OnBecameInvisible()
    {
        Enabled = false;
    }
}
