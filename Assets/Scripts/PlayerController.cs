using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject victoryScreen;


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

        float moveX = Input.GetAxis("Horizontal");
        if (!gameManager.gameOver && isGrounded)//make the Player move if the game is active
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }

        if (moveX > 0 && faceRight)//make the Player look to the direction he moves to
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

        if (Input.GetKeyDown(KeyCode.Space) /* && extraJumps > 0 */&& isGrounded) //make the Player jump
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
        if (!gameManager.gameOver)//make the Player looking at the direction he moves to
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
            //Check to see if it is the last scene of the game. If yes then show victory screen, if no then show Next Level button
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            {
                victoryScreen.gameObject.SetActive(true);
            }
            else
                winScreen.gameObject.SetActive(true);
        }
    }
}


