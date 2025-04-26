using UnityEngine;

public class Door: MonoBehaviour
{
    public GameObject interactButtonUI; // Assign the button UI in the Inspector

    void Start()
    {
      //  interactButtonUI.SetActive(false); // Hide by default
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hi");
            interactButtonUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("bye");
            interactButtonUI.SetActive(false);
        }
    }
}
