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

        public void Execute(GameObject player, int throttle)
        {
            if(gm.GetCurrentState() == PauseCommand.GameStates.Playing)
            {
                var rat = player.GetComponent<Rigidbody2D>();
                if(rat.velocity.y > -throttle)
                {
                    // Jump if not already jumping
                    rat.AddForce(new Vector2(0f, -20f));
                }
            }
        }
    }
}
