using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public Transform sword;
    public float attackRange = 0.5f;
    public int attackDamage;
    public LayerMask enemyLayers;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Attack();
        }
    }

    void Attack()
    { 
        Vector3 originalPosition = sword.transform.position;
        sword.transform.position = new Vector3(sword.transform.position.x + 0.5f, sword.transform.position.y, sword.transform.position.z - 1);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("You hit this nigga");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        StartCoroutine(ResetSwordPosition(originalPosition));
    }

    IEnumerator ResetSwordPosition(Vector3 originalPosition)
    {
        yield return new WaitForSeconds(0.5f);
        sword.transform.position = originalPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
