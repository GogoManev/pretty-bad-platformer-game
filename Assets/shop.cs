using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject player;
    public GameObject button;

    private void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        button.SetActive(false);
        if(player != null && player.transform.position.x <= 63 && player.transform.position.x >= 54)
        {
            showButton();
            }
    }

    public void showButton()
    {
        button.SetActive(true);
    }
}
