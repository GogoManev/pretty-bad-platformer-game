using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Player player;

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CurrentScene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetFloat("X", Player.instance.transform.position.x);
        PlayerPrefs.SetFloat("Y", Player.instance.transform.position.y);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
        Player.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), 0);
    }
    

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Player.instance.health = 100;
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentScene"));
    }
}
