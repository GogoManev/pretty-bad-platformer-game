using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;

    private Rigidbody2D rb;
    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
    }

    void FixedUpdate()
    {
        float moveDirection = movingRight ? 1 : -1;
        rb.linearVelocity = new Vector2(moveSpeed * moveDirection, rb.linearVelocity.y);

        if (Mathf.Abs(rb.position.x - startPos.x) >= moveDistance)
        {
            movingRight = !movingRight;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
