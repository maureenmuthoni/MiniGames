using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Camera mainCam;
    public Ray bulletPath;
    public LayerMask hitLayer;
    public float maxDistance = 1000f;
    
    void OnDrawGizmos()
    {
        bulletPath = mainCam.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(bulletPath.origin, bulletPath.origin + bulletPath.direction * maxDistance);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletPath = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(bulletPath, out hit, maxDistance, hitLayer))
            {
                GameObject hitObject = hit.collider.gameObject;

                Destroy(hitObject);
            }
        }
    }
}


