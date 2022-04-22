using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{
    private Animator enemyAnim;
    public float speed = 2;
    private float rightBound = 50;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
     
        if (transform.position.x > rightBound)
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
