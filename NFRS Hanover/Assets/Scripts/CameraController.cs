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
		var targetPosition = new Vector3(this.Target.transform.position.x + 10, this.ManagedCamera.transform.position.y, this.ManagedCamera.transform.position.z);
		// Set camera's position to player's position.
        this.ManagedCamera.transform.position = targetPosition;

    }
}
