using UnityEngine;
using Hanover.Physics;

namespace Hanover.CommandPattern
{
    // Interface for axis inputs (i.e. moving left and right)
    public interface IPhysicsCommand
    {
        void Execute(GameObject player, Vector2 axes, PlayerPhysics physics);
    }

    // General command pattern interface
    public interface ICommand
    {
        void Execute(GameObject target);
    }
}
