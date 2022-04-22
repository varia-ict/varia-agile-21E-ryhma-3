using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool faceRight = false;
    public bool inAtackMode;
    public long startAtackTime;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck; //checking the ground
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;
    private int coins = 0;
    [SerializeField] private Text coinsText;
    public AudioClip coinsSound;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float moveX = Input.GetAxis("Horizontal"); //player moves
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (moveX > 0 && faceRight)
        {
            flip();
        }
        if (moveX < 0 && !faceRight)
        {
            flip();
        }

        
    }

    private void Update()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) //player jumps
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    private void OnTriggerEnter2D(Collider2D collision) //pick up
    {

        if (collision.gameObject.tag == "PickUp")
        {
           
            coins++;
            coinsText.text = "Coins: " + coins;
            AudioSource.PlayClipAtPoint(coinsSound, transform.position);
            Destroy(collision.gameObject);
        }
    }
}


