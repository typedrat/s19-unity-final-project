using UnityEngine;

namespace CommandPattern
{
    /*
    /       Takes the player gameobject and horizontal axis as input.
    /   If you want to make the movement speed vary based on the strength
    /   of the input (i.e. how far a controller joystick is held down), use
    /   the axis input.
    /
    /       If you don't want to allow for varied movement speeds, just disregard
    /   the axis input.
    /
    /   Axis will always be a positive floating point number from 0 to 1.
    */
    public class MoveLeftCommand : MonoBehaviour, IAxisCommand
    {

        private PauseCommand gm;
        //private AudioSource audio;

        void Start() {
          gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PauseCommand>();
        }

        public void Execute(GameObject player, float axis, bool throttle)
        {
            if (gm.GetCurrentState() == PauseCommand.GameStates.Playing)
            {
                // MoveLeftCommand
                //player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20f, 0f) * axis);
                var rat = player.GetComponent<Rigidbody2D>();
                player.transform.rotation = Quaternion.identity;
                player.transform.Rotate(0, 180, 0);
                if(!throttle || (throttle && rat.velocity.x > -5))
                {
                    // Jump if not already jumping
                    rat.AddForce(new Vector2(-20f, 0f) * axis);
                }
            }
            //GetComponent<AudioSource>().Play();
        }
    }
}
