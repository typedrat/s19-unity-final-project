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

        public void Execute(GameObject player, bool throttle)
        {
            if (gm.GetCurrentState() == PauseCommand.GameStates.Playing)
            {
                var rat = player.GetComponent<Rigidbody2D>();
                if(!throttle || (throttle && rat.velocity.y < 5))
                {
                    // Jump if not already jumping
                    rat.AddForce(new Vector2(0f, 20f));
                }
            }
        }
    }
}
