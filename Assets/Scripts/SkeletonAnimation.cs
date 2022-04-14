using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    private Animator anim;
    public float speed = 3;
    private float leftBound = -14;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        anim.SetBool("isWalking", true);

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

    }

    
}
