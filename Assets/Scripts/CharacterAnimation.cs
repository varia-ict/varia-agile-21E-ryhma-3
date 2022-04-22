using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    public long startAtackTime = 0;
    



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        if (Input.GetKey(KeyCode.G))
        {
            anim.SetTrigger("Attack");
            startAtackTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) //attacking enemies
    {
        Debug.Log("Attack");

        if (collision.gameObject.tag == "Enemy")
        {
            var time = DateTimeOffset.Now.ToUnixTimeMilliseconds(); //play enemies death animation after killing
            if (startAtackTime - time > -500)
            {
                var hellSkeletonAnimator = collision.gameObject.GetComponent<HellSkeletonAnim>();
                if (hellSkeletonAnimator != null)
                {
                    hellSkeletonAnimator.KillWithAnimation();
                }
               
                var ghostAnimator = collision.gameObject.GetComponent<GhostAnimation>();
                if(ghostAnimator != null)
                {
                    ghostAnimator.KillWithAnimation();
                }

            }
            else //kill the player if it didn't attack
            {
                Destroy(gameObject);
            }
        }

    }

}
