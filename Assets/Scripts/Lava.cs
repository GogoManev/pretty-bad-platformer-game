using UnityEngine;

public class Lava : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
                if (Player.instance.health > 0)
                {
                    Player.instance.canMove = false;
                    Player.instance.TakeDamage(Player.instance.health);
                } else if(Player.instance.health <= 0)
                {
                    Player.instance.canMove = false;
                }
                
            
        }
    }