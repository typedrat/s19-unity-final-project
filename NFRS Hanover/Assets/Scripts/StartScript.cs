using UnityEngine;
using System.Collections;


public class StartScript : MonoBehaviour
{
    public void OnStartGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
