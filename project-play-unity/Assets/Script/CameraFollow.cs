using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Adjusted default offset

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned for camera follow!");
            return;
        }

        // Use negative offset.x to flip the camera horizontally
        Vector3 desiredPosition = target.position + new Vector3(-offset.x, offset.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target.position, Vector3.up);
    }
}