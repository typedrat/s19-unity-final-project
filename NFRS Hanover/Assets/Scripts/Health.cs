using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int MaxHP = 100;
    [SerializeField]
    public Slider Slider;
    public int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {   
        Slider.value = MaxHP;
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        ShowHPSlider();
        
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
