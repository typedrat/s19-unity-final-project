using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField]
    private float TimeToFire = 1.5f, Timer = 0f;

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

    private void OnBecameVisible()
    {
        Enabled = true;
    }

    private void OnBecameInvisible()
    {
        Enabled = false;
    }
}
