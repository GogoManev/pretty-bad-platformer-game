using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;
    public Transform target;
    public float beginningCoords;
    public float endingCoords;
    public Vector3 offset = new(0, 1f, -0.5f);
    private void Awake()
    {
        instance = this;
    }

    private void LateUpdate()
    {
        Vector3 position = target.position + offset;
        position.x = Mathf.Clamp(position.x, beginningCoords, endingCoords);
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}