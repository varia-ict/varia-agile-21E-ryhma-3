using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameManager gameManager;
    public Animator enemyAnim;
    public float speed = 2;
    private float rightBound = 100;
    private float leftBound = -100;
    bool dead;
    public bool rightDirectionFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            enemyAnim.SetBool("isWalking", true);
            var directionVector = rightDirectionFlag ? Vector3.right : Vector3.left;
            transform.Translate(directionVector * Time.deltaTime * speed);
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    public void KillWithAnimation() //death animation
    {
        if (!dead)
        {
            dead = true;
            Debug.Log("startDeath animation");
            enemyAnim.SetBool("death", true);
            Destroy(this.gameObject, 1);
        }
    }

}
