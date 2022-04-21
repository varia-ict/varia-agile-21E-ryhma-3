using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellAnimation : MonoBehaviour
{
    private Animator enemyAnim;
    public float speed = 3;
    private float leftBound = -14;
    public int enemyHealth = 100;
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
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

    }



    public void KillWithAnimation()
    {
        if (!dead)
        {
            dead = true;
            //    enemyAnim.SetTrigger("death");
            //    Destroy(gameObject);
            //}
            Debug.Log("startDeath animation");
            enemyAnim.SetBool("death", true);
            Destroy(this.gameObject, 5);
        }
    }

}




    
    
        
