using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
