using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    public Transform groundCheck; //checking the ground
    public LayerMask whatIsGround;
    [SerializeField] private Sprite[] pickupSprites;
    [SerializeField] public Text scoreText;
    public ImageEffectAllowedInSceneView GetImage;
    public AudioClip coinsSound;
    public GameObject winScreen;


    public float speed;
    public float jumpForce;
    public float checkRadius;

    public long startAtackTime;

    private bool isGrounded;
    private bool faceRight = false;
    public bool inAtackMode;

    private int extraJumps;
    public int extraJumpValue;
    private int pickup = 0;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float moveX = Input.GetAxis("Horizontal"); //player moves
        if (!gameManager.gameOver && isGrounded)
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }

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
        if (isGrounded == true && !gameManager.gameOver)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) /* && extraJumps > 0 */&& isGrounded) //player jumps
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        /* else if (Input.GetKeyDown(KeyCode.Space) && extraJumps < 2)
         {
             rb.velocity = Vector2.up * jumpForce;
         }
        */
    }

    void flip()
    {
        if (!gameManager.gameOver)//make the Player looking at the direction he move to
        {
            faceRight = !faceRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision) //The Player collects pickups with colliding
    {

        if (collision.gameObject.tag == "PickUp")
        {
            pickup++;
            scoreText.text = pickup + " / " + score;
            AudioSource.PlayClipAtPoint(coinsSound, transform.position);
            Destroy(collision.gameObject);
        }

        if (pickup == score)
        {
            winScreen.gameObject.SetActive(true);
        }
    }
}


