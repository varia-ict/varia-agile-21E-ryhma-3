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
        if (!gameManager.gameOver)//make the enemies move if the game is active
        {
            enemyAnim.SetBool("isWalking", true);
            var directionVector = rightDirectionFlag ? Vector3.right : Vector3.left;
            transform.Translate(directionVector * Time.deltaTime * speed);
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
        //destroy the enemies if they are not in the boards
        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    public void KillWithAnimation() //play the enemie's death animation if it's dead
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
