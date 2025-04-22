using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public bool canMove = true;
    public bool isGrounded = true;
    public float speed = 5f;
    public float jumpForce = 250f;
    public int health;
    public Slider healthBar;
    public GameObject tspmo;
    public GameObject gameOverScreen;

    private Rigidbody2D rb;
    private Vector3 originalScale;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(health > 0)
        {
            if (canMove)
            {
                transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z); // Face left
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z); // Face right
            }
        }


            if (Input.GetKeyDown(KeyCode.Space) && canMove && isGrounded)
            {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
            }
        }

        if (health <= 0)
        {
            Die();
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


    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
    }

    void Die()
    {
        canMove = false;
        isGrounded = false;
        gameOverScreen.SetActive(true);
    }
}
