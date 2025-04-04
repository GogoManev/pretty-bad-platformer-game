using UnityEngine;
using UnityEngine.UI;

public class muncho : MonoBehaviour
{
    public int initial_health = 100;
    public int current_health;
    public GameObject tspmo;
    public AudioSource source;
    public Slider healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_health = initial_health;
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(10);
            source.Play();
        }
    }

    public void TakeDamage(int damage)
    {
        current_health -= damage;
        Debug.Log("Enemy took damage! Current HP: " + current_health);
        healthbar.value = current_health;
        if (current_health < 0)
        {
            Die();
        }

    }

    void Die()
    {
        tspmo.SetActive(false);
    }
}
