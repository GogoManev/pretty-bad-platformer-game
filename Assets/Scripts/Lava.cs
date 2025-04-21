using UnityEngine;

public class Lava : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        
            if (player != null)
            {
                while (Player.instance.health > 0)
                {
                    Player.instance.canMove = false;
                    Player.instance.TakeDamage(1);
                }
                
            }
        }
    }