using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellAnimation : MonoBehaviour
{
    private Animator enemyAnim;
    public float speed = 3;
    private float leftBound = -14;
    public int enemyHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        enemyAnim.SetBool("isWalking", true);


        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

    }

    public void KillWithAnimation() {
        Debug.Log("startDeath animation");
        enemyAnim.SetTrigger("death");
        speed = 0;
        Destroy(this.gameObject, 0);
    }
    

}




    
    
        
