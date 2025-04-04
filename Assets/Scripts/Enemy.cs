using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int initial_health = 100;
    public int current_health;
    public GameObject tspmo;
    public Transform enemy;
    public Slider healthbar;
    private float enemyX;
    
    void Start()
    {
        enemyX = enemy.transform.position.x;
        current_health = initial_health;
    }

    private void Update()
    {
        enemyX -= 0.001f;
        enemy.transform.position = new Vector2(enemyX, enemy.transform.position.y);
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        current_health -= damage;
        Debug.Log("Enemy took damage! Current HP: " + current_health);
        healthbar.value = current_health;
        if (current_health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        tspmo.SetActive(false);
    }
}
