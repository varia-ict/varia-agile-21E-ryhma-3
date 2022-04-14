using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimation : MonoBehaviour
{
    private Animator anim;
    public float speed = 2;
    private float rightBound = 50;
        

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        anim.SetBool("isWalk", true);

        if (transform.position.x > rightBound)
        {
            Destroy(gameObject); 
        }
    }

    
}
