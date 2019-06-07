using UnityEngine;

namespace CommandPattern
{
    // Interface for axis inputs (i.e. moving left and right)
    public interface IAxisCommand
    {
        void Execute(GameObject player, float axis, bool throttle);
    }

    // General command pattern interface
    public interface ICommand
    {
        void Execute(GameObject player, bool throttle);
    }
}
