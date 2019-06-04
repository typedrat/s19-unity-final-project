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
    public class MoveRightCommand : MonoBehaviour, IAxisCommand
    {
        public void Execute(GameObject player, float axis)
        {
            // MoveRightCommand
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f, 0f) * axis);
        }
    }
}