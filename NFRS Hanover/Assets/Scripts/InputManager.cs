using Hanover.CommandPattern;
using Hanover.Physics;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Command Scripts
    private IPhysicsCommand GroundControl;
    private IPhysicsCommand AirControl;
    private IPhysicsCommand GravityToggle;
    private ICommand Pause;

    // Player object
    private GameObject Player;

    // Paused game state
    private bool IsPaused = false;
    private PlayerPhysics Physics;

    void Start()
    {
        IsPaused = false;
        Player = GameObject.FindGameObjectWithTag("Player");

        // Add the necessary components to the player
        GroundControl = Player.AddComponent<GroundControlCommand>();
        AirControl = Player.AddComponent<AirControlCommand>();
        GravityToggle = Player.GetComponent<GravityToggleCommand>();
        Pause = gameObject.AddComponent<PauseCommand>();
        
        Physics = Player.GetComponent<PlayerPhysics>();
    }

    void Update()
    {
        if (!IsPaused)
        {
            Vector2 axes = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Input.GetButtonDown("Jump"))
            {
                GravityToggle.Execute(Player, axes, Physics);
            }

            if (Physics.GravityEnabled)
            {
                GroundControl.Execute(Player, axes, Physics);
            }
            else
            {
                AirControl.Execute(Player, axes, Physics);
            }
        }

        if (Input.GetButtonDown("Pause"))
        {
            IsPaused = !IsPaused;

            Pause.Execute(gameObject);
        }
    }

    // Public function to be used by the pause menu screen
    //  Allows all of the pausing/input to be more unified
    public void Resume()
    {
        IsPaused = !IsPaused;

        Pause.Execute(gameObject);
    }
}
