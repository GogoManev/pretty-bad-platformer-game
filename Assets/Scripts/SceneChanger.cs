using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger1 : MonoBehaviour
{
    public int scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Player.instance.transform.position.x < CameraControl.instance.beginningCoords + 20f)
        {
            Player.instance.transform.position = new Vector3
                (collision.transform.position.x - 1f, collision.transform.position.y, Player.instance.transform.position.z);
        }
        else
        {
            Player.instance.transform.position = new Vector3
                (collision.transform.position.x + 1f, collision.transform.position.y, Player.instance.transform.position.z);
        }
        {

        }

        SceneManager.LoadScene(scene);
    }
}
