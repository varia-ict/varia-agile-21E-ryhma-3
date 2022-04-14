using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private bool faceRight = false;
    private Animator anim;
    public bool inAtackMode;
    public long startAtackTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); //player moves

        transform.Translate(Vector2.right * moveX * Time.deltaTime * speed);

        if (moveX > 0 && faceRight)
        {
            flip();
        }
        if (moveX < 0 && !faceRight)
        {
            flip();
        }

        if (Input.GetKeyDown(KeyCode.Space)) //player jumps
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }

    }

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

}


