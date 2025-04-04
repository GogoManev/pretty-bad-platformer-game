using UnityEngine;

public class muncho : MonoBehaviour
{
    public int initial_health = 100;
    public int current_health;
    public GameObject tspmo;
    public AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_health = initial_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health < 0)
        {
            tspmo.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            source.Play();
        }
    }
}
