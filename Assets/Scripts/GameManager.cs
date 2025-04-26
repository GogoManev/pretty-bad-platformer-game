using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isLoaded = false;
    public void Awake()
    {
        instance = this;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetFloat("X", Player.instance.transform.position.x);
        PlayerPrefs.SetFloat("Y", Player.instance.transform.position.y);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
        isLoaded = true;
        Player.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), 0);
    }
    

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        LoadGame();
    }
}
