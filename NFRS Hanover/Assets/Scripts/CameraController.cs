using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{
    [SerializeField] protected GameObject Target;
    private Camera ManagedCamera;

    private void Awake()
    {
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
    }

    // Use the LateUpdate message to avoid setting the camera's position before
    // GameObject locations are finalized.
    void LateUpdate()
    {
        Debug.Log(this.ManagedCamera.orthographicSize);
		var targetPosition = new Vector3(this.Target.transform.position.x + 10, this.ManagedCamera.transform.position.y, this.ManagedCamera.transform.position.z);
        if(targetPosition.x < this.ManagedCamera.transform.position.x)
        {
            targetPosition.x = this.ManagedCamera.transform.position.x;
        }

        // If Player touches left-boundary of camera
        if(this.Target.transform.position.x < this.ManagedCamera.transform.position.x - (this.ManagedCamera.orthographicSize * 2))
        {
            this.Target.transform.position = new Vector3(this.ManagedCamera.transform.position.x - (this.ManagedCamera.orthographicSize * 2), this.Target.transform.position.y, this.Target.transform.position.z);
            var playerBody = this.Target.GetComponent<Rigidbody2D>();
            playerBody.velocity = new Vector2(0, playerBody.velocity.y);
        }
		// Set camera's position to player's position.
        this.ManagedCamera.transform.position = targetPosition;

    }
}
