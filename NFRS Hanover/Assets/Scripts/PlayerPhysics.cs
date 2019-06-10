using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanover.Physics
{
    public class PlayerPhysics : MonoBehaviour
    {
        private Rigidbody2D Physics;
        private SpriteRenderer Renderer;

        [SerializeField]
        private bool _GravEnabled = true;

        public bool GravityEnabled {
            get { return _GravEnabled; }
            set
            {
                Physics.gravityScale = value ? 3.0f : 0.0f;
                _Speed = Physics.velocity.magnitude;
                _GravEnabled = value;

                Physics.freezeRotation = value;
                if (value)
                {
                    gameObject.transform.rotation = Quaternion.identity;
                }
            }
        }

        [SerializeField]
        private float BaseGroundMovementForce, VelocityCap;
        public float AntigravityDuration = 3.0f;

        private float _Speed;
        public float Speed {
            get
            {
                if (_GravEnabled)
                {
                    return Physics.velocity.magnitude;
                }
                else
                {
                    return _Speed;
                }
            }
        }

        private Vector2 Direction;

        public void ToggleGravity()
        {
            GravityEnabled = !GravityEnabled;
        }

        void Start()
        {
            Physics = gameObject.GetComponent<Rigidbody2D>();
            Renderer = gameObject.GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            if (Physics.velocity.magnitude > VelocityCap)
            {
                Physics.velocity = Physics.velocity.normalized * VelocityCap;
            }

            Renderer.flipX = Physics.velocity.x > 0.0f;
        }

        public void GroundControl(Vector2 axes)
        {
            axes.y = 0;

            Physics.AddForce(BaseGroundMovementForce * axes, ForceMode2D.Impulse);
        }

        public void AirControl(Vector2 axes)
        {
            Physics.velocity = Speed * axes.normalized;
        }
    }
}
