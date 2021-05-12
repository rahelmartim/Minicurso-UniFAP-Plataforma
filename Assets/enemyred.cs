using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyred : MonoBehaviour
{
    public float speed;
    public float timeTotal;
    private float timeElapsed;

    private Rigidbody2D body;
    public bool behaviour;
    //True --> right
    //false --> left    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timeElapsed = 0;
    }

    
    void Update()
    {        
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeTotal)
        {
            behaviour = !behaviour;
            timeElapsed = 0;
        }

        if (behaviour == true)
        {//mover para direita
            GetComponent<SpriteRenderer>().flipX = false;
            body.velocity = Vector2.right * speed;
        }
        else
        {//mover para esquerda
            GetComponent<SpriteRenderer>().flipX = true;
            body.velocity = Vector2.left * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }


}
