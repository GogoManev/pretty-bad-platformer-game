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
    public GameObject pauseScreen;
    private Rigidbody2D rb;
    private Vector3 originalScale;
    public float maxJumpHoldTime = 1f;
    public float jumpHoldForce = 6f;
    private float jumpHoldTimer;
    private bool isJumping;
    private bool isPaused = false;


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

        if(GameManager.instance.isLoaded == true)
        {
            instance.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), 0);
        }
        
    }
    void Update()
{
    if (health <= 0)
    {
        Die();
    }

    if (health > 0 && !isPaused)
    {
        if (Input.GetKeyDown(KeyCode.Space) && canMove && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            isJumping = true;
            jumpHoldTimer = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpHoldTimer < maxJumpHoldTime)
            {
                rb.AddForce(new Vector2(0, jumpHoldForce * Time.deltaTime), ForceMode2D.Impulse);
                jumpHoldTimer += Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

        PauseGame();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (health > 0 && !isPaused && canMove)
        {
                transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z); // left
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z); // right
                }
        }
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
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

    private void Die()
    {
        Destroy(gameObject);
        canMove = false;
        isGrounded = false;
        gameOverScreen.SetActive(true);
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!isPaused)
            {
                pauseScreen.SetActive(true);
                isPaused = true;
            }
            else
            {
                pauseScreen.SetActive(false);
                isPaused = false;
            }
            
        }
    }
}
