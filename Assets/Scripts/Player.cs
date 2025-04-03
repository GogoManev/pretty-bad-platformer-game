using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public static Player instance;
    public bool canMove = true;
    public bool isGrounded = true;
    public float speed = 5f;
    public float jumpForce = 250f;
    public int currScene;
    private Rigidbody2D rb;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (canMove)
        {
            transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        }


        if (Input.GetKeyDown(KeyCode.Space) && canMove && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
        }
    }
    
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
