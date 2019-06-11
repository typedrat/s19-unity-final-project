using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int MaxHP = 100;
    [SerializeField]
    private Slider Slider;
    [SerializeField]
    private int CurrentHP;

    private AudioSource Audio;

    private PlayerFlashing Flashing;

    private ScreenShake c_Shake;
    public float collisionPauseTime = 0.1f;
    private bool isPaused = false;
    private float currentPauseTime = 0f;

    [SerializeField] private bool isInvul = false;
    [SerializeField] private float invulTime = 2f;
    private float currentInvulTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();

        Slider.value = MaxHP;
        CurrentHP = MaxHP;
        Flashing = gameObject.GetComponent<PlayerFlashing>();
        c_Shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {

        // invulnerability and flashing
        if (isPaused)
        {
            currentPauseTime += Time.unscaledDeltaTime;
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

    public void AddHealth(int health)
    {
        CurrentHP += health;
        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
        ShowHPSlider();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvul)
        {
            CurrentHP -= damage;
            ShowHPSlider();
            Audio.Play();
            
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
                Destroy(this.gameObject);
                Debug.Log("YOU DIED");
                //activate death info
                GameObject parentObj = GameObject.Find("Main Camera");
                GameObject DeathInfo = parentObj.transform.Find("DeathInfo").gameObject;
                DeathInfo.SetActive(true);
                //pause
                Time.timeScale = 0f;
            }
            else
            {
                isInvul = true;
                c_Shake.Shake(.25f);

                isPaused = true;
                Time.timeScale = 0f;
                Flashing.StartFlashing();
            }
        }
    }

    public void ShowHPSlider()
    {
        Debug.Log(Slider.value);
        Slider.value = (float)CurrentHP;
        Debug.Log(Slider.value);
    }
}
