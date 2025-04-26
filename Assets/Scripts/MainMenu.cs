using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Destroy(Player.instance);
        Destroy(CanvasManager.instance);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("CurrentScene", 1);
        PlayerPrefs.SetFloat("X", 0.5f);
        PlayerPrefs.SetFloat("Y", 0f);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
