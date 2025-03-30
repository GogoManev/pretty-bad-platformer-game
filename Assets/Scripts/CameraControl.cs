using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public GameObject Player;
    public Vector3 offset = new(0, 0, -10);
    void Update()
    {

    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}