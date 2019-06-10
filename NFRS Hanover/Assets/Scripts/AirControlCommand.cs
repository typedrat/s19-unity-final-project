using UnityEngine;
using System.Collections;
using Hanover.CommandPattern;
using Hanover.Physics;

public class AirControlCommand : MonoBehaviour, IPhysicsCommand
{
    public void Execute(GameObject player, Vector2 axes, PlayerPhysics physics)
    {
        physics.AirControl(axes);
    }
}
