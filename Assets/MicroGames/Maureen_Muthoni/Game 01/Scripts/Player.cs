using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StirlingMulvey;

namespace MaureenMuthoniGame1
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        Rigidbody myRigi;
        public float rotationSpeed = 360f;
        public float gravity = 9.8f;
        public float speed = 50f;
        public float maxAcceleration = 10f;
        public bool isJumping = true;
        public float jumpHeight = 2f;
        public float rayDistance = 1.1f;
        public LayerMask groundLayer;

        private bool grounded = false;
        private float inputH, inputV;
        private Vector3 movement;
        private Ray floorRay;

        void OnDrawGizmos()
        {
            RecalculateRays();
            Gizmos.color = Color.red;
            Gizmos.DrawLine(floorRay.origin, floorRay.origin + floorRay.direction * rayDistance);
        }

        // Use this for initialization
        void Awake()
        {
            myRigi = GetComponent<Rigidbody>();
            myRigi.useGravity = true;
        }

        void RecalculateRays()
        {
            floorRay = new Ray(transform.position, Vector3.down);
        }

        void Update()
        {
            inputV = Input.GetAxis("Vertical");
            inputH = Input.GetAxis("Horizontal");
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * inputH * Time.deltaTime, Vector3.up);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            RecalculateRays();
            if (Physics.Raycast(floorRay, rayDistance, groundLayer))
            {
                grounded = true;
            }

            if (grounded)
            {
                // Calculate how fast we should be moving
                Vector3 targetVelocity = new Vector3(inputH, 0f, inputV);
                targetVelocity *= speed;
                targetVelocity = transform.TransformDirection(targetVelocity);
                
                // Apply a force that attempts to reach targetVelocity
                Vector3 vel = myRigi.velocity;
                Vector3 accel = (targetVelocity - vel);
                accel.x = Mathf.Clamp(accel.x, -maxAcceleration, maxAcceleration);
                accel.y = 0;
                accel.z = Mathf.Clamp(accel.z, -maxAcceleration, maxAcceleration);
                myRigi.AddForce(accel, ForceMode.VelocityChange);

                // Jump            
                if (isJumping && Input.GetButton("Jump"))
                {
                    float jumpSpeed = Mathf.Sqrt(2 * jumpHeight * gravity);
                    myRigi.velocity = new Vector3(vel.x, jumpSpeed, vel.z);
                    myRigi.AddForce(new Vector3(0, -gravity * myRigi.mass, 0));
                }
            }

            // We apply gravity manually for more tuning control
            myRigi.AddForce(new Vector3(0, -gravity * myRigi.mass, 0));

            grounded = false;
        }
    }
}
