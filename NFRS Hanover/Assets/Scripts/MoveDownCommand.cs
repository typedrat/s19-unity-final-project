using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandPattern;

namespace CommandPattern {
    public class MoveDownCommand : MonoBehaviour, ICommand
    {
        public void Execute(GameObject player, bool throttle)
        {
            var rat = player.GetComponent<Rigidbody2D>();

            if (!throttle || rat.velocity.y > -5.0f)
            {
                rat.AddForce(new Vector2(0f, -20f));
            }
        }
    }
}
