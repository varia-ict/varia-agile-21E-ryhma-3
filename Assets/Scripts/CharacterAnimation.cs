using System;
using UnityEngine;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;
    private long startAtackTime = 0;
    public long atackDurationTime = 100;
    public long atackCooldownTime = 150;
    public AudioSource playerAudio;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
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
            var time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if(time >= startAtackTime + atackCooldownTime)
            {
                anim.SetTrigger("Attack");
                startAtackTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) //attacking enemies
    {

        Debug.Log("Attack");

        if (collision.gameObject.tag != "Enemy")
        {
            return;
        }
        var time = DateTimeOffset.Now.ToUnixTimeMilliseconds(); //play enemies death animation after killing
        if (startAtackTime - time > -atackDurationTime)
        {
            var enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                enemyController.KillWithAnimation();
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }
        }
        else //kill the player if it didn't attack
        {
            Destroy(gameObject);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}




   