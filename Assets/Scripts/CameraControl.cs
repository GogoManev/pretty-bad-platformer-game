using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;
    public Transform target;
    public GameObject Player;
    public float beginningCoords;
    public float endingCoords;
    public Vector3 offset = new(0, 1f, -0.5f);
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;


        if (transform.position.x < beginningCoords)
        {
            transform.position = new Vector3(beginningCoords, transform.position.y, transform.position.z);
        }

        if(transform.position.x > endingCoords)
        {
            transform.position = new Vector3(endingCoords, transform.position.y, transform.position.z);
        }
    }
}