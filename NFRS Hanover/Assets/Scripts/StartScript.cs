using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartScript : MonoBehaviour
{
    public void OnStartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
