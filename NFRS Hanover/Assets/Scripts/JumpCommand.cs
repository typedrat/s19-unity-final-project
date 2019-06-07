using UnityEngine;

namespace CommandPattern
{
    /*
    /   Takes the player gameobject as input.
    */

    public class JumpCommand : MonoBehaviour, ICommand
    {

        [SerializeField]
        private AudioClip JumpClip;
        private AudioSource Audio;

        void Start() {
            Audio = GetComponent<AudioSource>();
            JumpClip = (AudioClip)Resources.Load("Audio/ratjump.mp3");
        }

        public void Execute(GameObject player, bool throttle)
        {
            Audio.PlayOneShot(JumpClip);
            var rat = player.GetComponent<Rigidbody2D>();
                
            if(!throttle || (throttle && rat.velocity.y < 5))
            {
                // Jump if not already jumping
                rat.AddForce(new Vector2(0f, 20f));
            }
        }
    }
}

