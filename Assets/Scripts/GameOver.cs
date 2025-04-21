using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Player player;
    void gameOverScreen()
    {
        gameObject.SetActive(true);
    }
    

    public void MainMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        player.health = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
