using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger1 : MonoBehaviour
{
    public int scene;
    public float x;
    public float y;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(scene);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Player.instance.transform.position = new Vector2(x, y);
        CameraControl cameraFollow = Camera.main.GetComponent<CameraControl>();
        if (cameraFollow != null)
        {
            cameraFollow.SetTarget(Player.instance.transform);
        }
    }
}