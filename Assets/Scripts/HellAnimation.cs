using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellAnimation : MonoBehaviour
{
    private Animator anim;
    public float speed = 3;
    private float leftBound = -14;
    public int enemyHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        anim.SetBool("isFlying", true);

        if(enemyHealth <= 0)
        {
            anim.SetTrigger("HellDeath");
        }


        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

        }
    

}




    
    
        
