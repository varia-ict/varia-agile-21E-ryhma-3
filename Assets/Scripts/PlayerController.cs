using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody2D rb;
    public Transform groundCheck; //checking the ground
    public LayerMask whatIsGround;
    [SerializeField] private Sprite[] pickupSprites;
    [SerializeField] private Text scoreText;
    public ImageEffectAllowedInSceneView GetImage;
    public AudioClip coinsSound;

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
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    private void OnTriggerEnter2D(Collider2D collision) //pick up
    {

        if (collision.gameObject.tag == "PickUp")
        {
            pickup++;
            scoreText.text = " x " + pickup;
            AudioSource.PlayClipAtPoint(coinsSound, transform.position);
            Destroy(collision.gameObject);
        }
    }
}


