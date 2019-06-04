using UnityEngine;

namespace CommandPattern
{
    /*
    /   Takes the player gameobject as input.
    */

    public class JumpCommand : MonoBehaviour, ICommand
    {
        public void Execute(GameObject player)
        {
            // Jump if not already jumping
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
        }
    }
}