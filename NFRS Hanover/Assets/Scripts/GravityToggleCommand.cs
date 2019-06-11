using Hanover.CommandPattern;
using Hanover.Physics;
using UnityEngine;

public class GravityToggleCommand : MonoBehaviour, IPhysicsCommand
{
    private ScreenShake c_Shake;

    [SerializeField]
    private float TotalDuration = 3.0f;
    private float Timer = 0.0f;
    private bool Active = false;
    private PlayerPhysics Physics = null;

    void Start()
    {
        c_Shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
    }

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
            c_Shake.SmallShake(0.1f);
        }
        else
        {
            Physics.GravityEnabled = true;
            Active = false;
            c_Shake.SmallShake(0.1f);
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
                c_Shake.SmallShake(0.1f);
            }
        }
    }
}
