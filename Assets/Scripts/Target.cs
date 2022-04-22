using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    public int pointValue;
    public AudioClip coinsSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //pick up
    {

        if (collision.gameObject.tag == "PickUp")
        {
            AudioSource.PlayClipAtPoint(coinsSound, transform.position);
            Destroy(collision.gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
