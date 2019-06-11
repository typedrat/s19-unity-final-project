using UnityEngine;
using Hanover.CommandPattern;

namespace Hanover.CommandPattern
{
    public class PauseCommand : MonoBehaviour, ICommand
    {
        public enum GameStates {Playing, Paused};

        private GameStates currentState = GameStates.Playing;
        private GameObject UICanvas;
        private AudioSource PauseSound;

        void Start()
        {
            currentState = GameStates.Playing;
            Time.timeScale = 1f;
            UICanvas = GameObject.FindGameObjectWithTag("PauseMenu");
            UICanvas.SetActive(false);
            PauseSound = gameObject.GetComponent<AudioSource>();
        }

        public GameStates GetCurrentState()
        {
            return currentState;
        }

        public void Execute(GameObject gameObject)
        {
            PauseSound.Play();

            switch(currentState) {
                case GameStates.Playing:
                    Time.timeScale = 0f;
                    currentState = GameStates.Paused;
                    UICanvas.SetActive(true);
                    break;
                case GameStates.Paused:
                    Time.timeScale = 1f;
                    currentState = GameStates.Playing;
                    UICanvas.SetActive(false);
                    break;
            }
        }
    }
}
