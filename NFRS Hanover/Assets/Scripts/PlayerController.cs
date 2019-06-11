using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Health Health;
    private PlayerFlashing Flashing;

    private ScreenShake c_Shake;
    public float collisionPauseTime = 0.1f;
    private bool isPaused = false;
    private float currentPauseTime = 0f;

    [SerializeField] private bool isInvul = false;
    [SerializeField] private float invulTime = 2f;
    private float currentInvulTime = 0f;

    private void Start()
    {
        Health = gameObject.GetComponent<Health>();
        Flashing = gameObject.GetComponent<PlayerFlashing>();
        c_Shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if (!isInvul)
            {
                Debug.Log("Hit laser!");
                Health.TakeDamage(10);

                isInvul = true;
                c_Shake.Shake(.25f);

                isPaused = true;
                Time.timeScale = 0f;

                Color color = this.GetComponent<SpriteRenderer>().color;
                color.a = .4f;
                this.GetComponent<SpriteRenderer>().color = color;

                Flashing.StartFlashing();
            }
        }

        if (isPaused)
        {
            currentPauseTime += Time.unscaledDeltaTime;
            Debug.Log(currentPauseTime);
            if(currentPauseTime >= collisionPauseTime)
            {
                isPaused = false;
                Time.timeScale = 1f;
                currentPauseTime = 0f;
            }
        }

        if (isInvul)
        {
            currentInvulTime += Time.deltaTime;
            if(currentInvulTime >= invulTime)
            {
                isInvul = false;
                currentInvulTime = 0f;
                Color color = this.GetComponent<SpriteRenderer>().color;
                color.a = 1f;
                this.GetComponent<SpriteRenderer>().color = color;
                Flashing.StopFlashing();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Hit laser!");
            if (!isInvul)
            {
                Debug.Log("Hit laser!");
                Health.TakeDamage(10);

                isInvul = true;
                c_Shake.Shake(.25f);

                isPaused = true;
                Time.timeScale = 0f;
                Color color = this.GetComponent<SpriteRenderer>().color;
                color.a = .4f;
                this.GetComponent<SpriteRenderer>().color = color;
                Flashing.StartFlashing();
            }
        }
    }
}
