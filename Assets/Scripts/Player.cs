using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    public bool canJump = true;
    public float speed = 5f;
    public float jumpForce = 250f;
    public Scene nextScene;
    private Rigidbody2D rb;
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


        if (Input.GetKeyDown(KeyCode.Space) && canMove && canJump)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));
        }

        if(transform.position.x > CameraControl.instance.endingCoords + 10f)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }


    void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
