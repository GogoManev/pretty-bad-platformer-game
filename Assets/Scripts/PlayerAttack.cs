using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public Transform sword;
    public float attackRange = 0.5f;
    public int attackDamage;
    public LayerMask enemyLayers;
    public Transform player;

    private void Start()
    {
        //sword.transform.position = new Vector3(player.transform.position.x - 0.35f, player.transform.position.y + 0.06f, player.transform.position.z);
        //sword.transform.position = new Vector3(0.15f, 0.06f, 0f);
        Debug.Log(sword.position);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }


    void Attack()
    {
        Debug.Log(sword.position);
        // move bi move bi ne --> sword.transform.position = new Vector3(sword.transform.position.x + 0.5f, sword.transform.position.y, sword.transform.position.z - 1); 
        sword.transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, player.transform.position.z - 1);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("You hit an enemy(nigga)");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        StartCoroutine(ResetSwordPosition());
    }

    IEnumerator ResetSwordPosition()
    {
        yield return new WaitForSeconds(0.5f);
        sword.transform.position = player.transform.position;
        sword.transform.position = new Vector3(player.transform.position.x + 0.37f, player.transform.position.y + 0.14f, player.transform.position.z);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    /*void Attack()
    { 
        Vector3 originalPosition = sword.transform.position;
        sword.transform.position = new Vector3(sword.transform.position.x + 0.5f, sword.transform.position.y, sword.transform.position.z - 1);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("You hit an enemy(nigga)");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        StartCoroutine(ResetSwordPosition(originalPosition));
    }

    IEnumerator ResetSwordPosition(Vector3 originalPosition)
    {
        yield return new WaitForSeconds(0.5f);
        sword.transform.position = originalPosition;
    }
    */
}
