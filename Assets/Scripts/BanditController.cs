using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    private GameObject player;
    public Animator anim;

    bool dead;
    public bool faceRight;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            rb.AddForce(lookDirection * speed);

            if (transform.position.x > player.transform.position.x && faceRight)
            {
                flip();
            }
            if (transform.position.x < player.transform.position.x && faceRight)
            {
                flip();
            }
        }


    }

    void flip()
    {
        if (!gameManager.gameOver)//make the Bandit looking at the direction to Player
        {
            faceRight = !faceRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void KillWithAnimation() //death animation
    {
        if (!dead)
        {
            dead = true;
            Debug.Log("startDeath animation");
            anim.SetBool("death", true);
        }
    }

}
