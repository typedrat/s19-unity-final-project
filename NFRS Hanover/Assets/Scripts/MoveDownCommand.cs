using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandPattern;

namespace CommandPattern {
    public class MoveDownCommand : MonoBehaviour, ICommand
    {
        private PauseCommand gm;

        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PauseCommand>();
        }

        public void Execute(GameObject gameObject)
        {
            if(gm.GetCurrentState() == PauseCommand.GameStates.Playing)
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -20f));
        }
    }
}
