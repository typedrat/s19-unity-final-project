using Hanover.CommandPattern;
using Hanover.Physics;
using UnityEngine;

public class GravityToggleCommand : MonoBehaviour, IPhysicsCommand
{
    [SerializeField]
    private float TotalDuration = 3.0f;
    private float Timer = 0.0f;
    private bool Active = false;
    private PlayerPhysics Physics = null;

    public void Execute(GameObject player, Vector2 axes, PlayerPhysics physics)
    {
        if (Physics == null)
        {
            Physics = physics;
            TotalDuration = Physics.AntigravityDuration;
        }

        if (Physics.GravityEnabled)
        {
            Timer = 0.0f;
            Physics.GravityEnabled = false;
            Active = true;
        }
        else
        {
            Physics.GravityEnabled = true;
            Active = false;
        }
    }

    void Update()
    {
        if (Active)
        {
            Timer += Time.deltaTime;

            if (Timer >= TotalDuration)
            {
                Active = false;
                Physics.GravityEnabled = true;
            }
        }
    }
}
