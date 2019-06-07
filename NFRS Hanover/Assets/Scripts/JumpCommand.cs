using UnityEngine;

namespace CommandPattern
{
    /*
    /   Takes the player gameobject as input.
    */

    public class JumpCommand : MonoBehaviour, ICommand
    {

        private PauseCommand gm;

        void Start() {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PauseCommand>();
        }

        public void Execute(GameObject player)
        {
            if (gm.GetCurrentState() == PauseCommand.GameStates.Playing)
            {
                // Jump if not already jumping
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
            }
        }
    }
}