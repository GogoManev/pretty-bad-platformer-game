using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetFloat("X", Player.instance.transform.position.x);
            PlayerPrefs.SetFloat("Y", Player.instance.transform.position.y);
        }
    }
}
