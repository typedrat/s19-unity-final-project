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


    // Start is called before the first frame update
    void Start()
    {
        // Add the necessary components to the player
        this.gameObject.AddComponent<MoveLeftCommand>();
        this.gameObject.AddComponent<MoveRightCommand>();
        this.gameObject.AddComponent<JumpCommand>();
        
        // Get references to the command components
        this.MoveLeft = this.gameObject.GetComponent<MoveLeftCommand>();
        this.MoveRight = this.gameObject.GetComponent<MoveRightCommand>();
        this.Jump = this.gameObject.GetComponent<JumpCommand>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump")) {
            this.Jump.Execute(this.gameObject);
        }
        if (horizontalMovement > 0.01) {
            this.MoveRight.Execute(this.gameObject, horizontalMovement);
        }
        if (horizontalMovement < -0.01) {
            this.MoveLeft.Execute(this.gameObject, -1 * horizontalMovement);
        }
    }
}
