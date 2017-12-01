using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KeepWithinScreen))]
public class Movement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Vector3 movement;

    private Vector3 direction;
    private KeepWithinScreen screenBounds;
    private float originalZ;

    // Use this for initialization
    void Start()
    {
        screenBounds = GetComponent<KeepWithinScreen>();
        direction = Random.onUnitSphere;
        originalZ = transform.position.z;
        movement = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement += direction * movementSpeed * Time.deltaTime;
        
        transform.position = new Vector3(movement.x, movement.y, originalZ);
    }

    void OnBecameInvisible()
    {
        direction *= -1;
    }
}
