using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumper : MonoBehaviour
{

    public float force;
    public Animator animControl;

    private void Start()
    {
        animControl = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animControl.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }
        
    }

}
