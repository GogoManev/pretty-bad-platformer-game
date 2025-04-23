using UnityEngine;

public class shop : MonoBehaviour
{
    public GameObject button;

    private void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
