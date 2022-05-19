using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] liveSprites;
    [SerializeField] private Text livesText;
    private GameManager gameManager;
    public GameObject player;
    public Animator anim;
    public AudioSource playerAudio;
    public AudioClip deathSound;
    new readonly Renderer renderer;
    private long startAtackTime = 0;
    public long atackDurationTime = 100;
    public long atackCooldownTime = 150;

    public float blinkTime = 0.1f;

    private int lives = 3;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("PlayerBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        livesText.text = " x " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.playerActive)//Player's running animation turns on
        {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))//Player's jumping animation turns on
            {
                anim.SetTrigger("jump");
            }
            if (Input.GetKey(KeyCode.G))//Player's attacking animation turns on
            {
                var time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                if (time >= startAtackTime + atackCooldownTime)
                {
                    anim.SetTrigger("Attack");
                    startAtackTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
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
            var banditController = collision.gameObject.GetComponent<BanditController>();
            if (enemyController != null)
            {
                enemyController.KillWithAnimation();
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }
            if (banditController != null)
            {
                banditController.KillWithAnimation();
            }
        }
        else //losing the lives if the Player collides with enemies without attack
        {
            var banditController = collision.gameObject.GetComponent<BanditController>();
            banditController.anim.SetTrigger("Attack");

            lives--;
            spriteRend.material = matBlink;
            livesText.text = " x " + lives;
            
            if (lives <= 0)
            {
                gameManager.GameOver();
            }
            else
            {
                Invoke("ResetMaterial", 0.1f);
            }
        }
    }


    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

}




