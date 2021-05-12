using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlat : MonoBehaviour
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("activate", 1f);
            Destroy(gameObject, 5f);
        }       
    }

    private void activate()
    {
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().gravityScale = 0.5f;
    }
}
