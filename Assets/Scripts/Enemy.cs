using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int initial_health = 100;
    public int current_health;
    public float speed;
    public int playerDamage;
    public GameObject tspmo;
    public Transform enemy;
    //public Slider healthbar;
    private float enemyX;
    
    void Start()
    {
        enemyX = enemy.transform.position.x;
        current_health = initial_health;
    }

    private void Update()
    {
        enemyX += speed;
        enemy.transform.position = new Vector2(enemyX, enemy.transform.position.y);
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            Player.instance.TakeDamage(playerDamage);
            Player.instance.transform.position = new Vector2(Player.instance.transform.position.x - 1f, Player.instance.transform.position.y);
        }
    }

    public void TakeDamage(int damage)
    {
        current_health -= damage;
        Debug.Log("Enemy took damage! Current HP: " + current_health);
        //healthbar.value = current_health;
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
