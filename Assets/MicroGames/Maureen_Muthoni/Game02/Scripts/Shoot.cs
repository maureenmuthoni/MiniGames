using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StirlingMulvey;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public Camera mainCam;
    public Ray bulletPath;
    public LayerMask hitLayer;
    public float maxDistance = 1000f;
    public GameObject canvasText;
    public float startTime = 0.5f;
    public GameObject[] count;


    public void Start()
    {
        GlobalGameManager.gameWon = false;
    }
    void OnDrawGizmos()
    {
        // Draw a ray from the camera to the mouse position
        bulletPath = mainCam.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(bulletPath.origin, bulletPath.origin + bulletPath.direction * maxDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if start time has passed
        if (Time.time > startTime)
        {
            // Clear the text
            canvasText.GetComponent<Text>().text = "";
        }
        count = GameObject.FindGameObjectsWithTag("Target");
        // if all targets are destroyed
        if (count.Length == 0)
        {
            // You Win!
            GlobalGameManager.gameWon = true;
            canvasText.GetComponent<Text>().text = "You Win!";
        }
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            bulletPath = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // if the ray hits an object with layer hitLayer
            if (Physics.Raycast(bulletPath, out hit, maxDistance, hitLayer))
            {
                // Register a hit
                GameObject hitObject = hit.collider.gameObject;
                // Destroy the gameobject
                Destroy(hitObject);
            }
        }
        if (GlobalGameManager.gameWon == false && Time.time > 5)
            canvasText.GetComponent<Text>().text = "You Lose";
    }
}


