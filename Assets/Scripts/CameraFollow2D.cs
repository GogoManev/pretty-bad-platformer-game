using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;        // Assign your player here
    public float smoothSpeed = 0.125f;
    public Vector3 offset;          // You can set this in the Inspector to adjust camera position

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
