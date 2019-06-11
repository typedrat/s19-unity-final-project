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

    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.GetComponent<AudioSource>();

        Slider.value = MaxHP;
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = CurrentHP;
    }

    public void TakeDamage(int damage)
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
    }

    public void ShowHPSlider()
    {
        Slider.value = CurrentHP;
    }
}
