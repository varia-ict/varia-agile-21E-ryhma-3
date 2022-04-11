using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellAnimation : MonoBehaviour
{
    private Animator anim;
    public float speed = 3;

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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            anim.SetTrigger("death");
        }
    }
}

