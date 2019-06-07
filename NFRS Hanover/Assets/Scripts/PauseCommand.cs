using UnityEngine;
using CommandPattern;

namespace CommandPattern
{
    public class PauseCommand : MonoBehaviour, ICommand
    {
        public enum GameStates {Playing, Paused};

        private GameStates currentState = GameStates.Playing;
        private GameObject UICanvas;

        void Start() {
            UICanvas = GameObject.FindGameObjectWithTag("UI");
            UICanvas.SetActive(false);
        }

        public GameStates GetCurrentState()
        {
            return currentState;
        }

        public void Execute(GameObject gameObject, bool throttle)
        {
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
