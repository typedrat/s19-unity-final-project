using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommandPattern;

public class InputManager : MonoBehaviour
{
    // Command Scripts
    private IAxisCommand MoveLeft;
    private IAxisCommand MoveRight;
    private ICommand Jump;
    private ICommand Pause;

    // Player object
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Add the necessary components to the player
        this.player.AddComponent<MoveLeftCommand>();
        this.player.AddComponent<MoveRightCommand>();
        this.player.AddComponent<JumpCommand>();
        this.gameObject.AddComponent<PauseCommand>();
        
        // Get references to the command components
        this.MoveLeft = this.player.GetComponent<MoveLeftCommand>();
        this.MoveRight = this.player.GetComponent<MoveRightCommand>();
        this.Jump = this.player.GetComponent<JumpCommand>();
        this.Pause = this.gameObject.GetComponent<PauseCommand>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) {
            this.Jump.Execute(this.player);
        }
        if (horizontalMovement > 0.01) {
            this.MoveRight.Execute(this.player, horizontalMovement);
        }
        if (horizontalMovement < -0.01) {
            this.MoveLeft.Execute(this.player, -1 * horizontalMovement);
        }
        if (Input.GetButtonDown("Pause")) {
            this.Pause.Execute(this.gameObject);
        }
    }
}
