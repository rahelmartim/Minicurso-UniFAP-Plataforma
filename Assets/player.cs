using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private Rigidbody2D bodyControl;
    private Animator controladorAnimacao;
    private SpriteRenderer controladorSprite;

    public float velocidadeMovimento;
    public float forcaPulo;
    private bool podePular;

    public Transform ponto;

    public Joystick joy;

    void Start()
    {
        podePular = false;
        bodyControl = GetComponent<Rigidbody2D>();
        controladorAnimacao = GetComponent<Animator>();
        controladorSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveControl();        
    }

    private void moveControl()
    {
        //1 --> d, seta direita
        //-1 --> a, seta esq
        float movimento = joy.Horizontal;

        if (movimento > 0)
        {
            controladorSprite.flipX = false;
            bodyControl.velocity = new Vector2(velocidadeMovimento, bodyControl.velocity.y);
        }
        else if(movimento < 0)
        {
            controladorSprite.flipX = true;
            bodyControl.velocity = new Vector2(-velocidadeMovimento, bodyControl.velocity.y);
        }
        else
        {
            controladorSprite.flipX = false;
            bodyControl.velocity = new Vector2(0, bodyControl.velocity.y);
        }

        controladorAnimacao.SetFloat("movimento", Mathf.Abs(movimento));
    }
    public void jumpControl()
    {
        podePular = Physics2D.Linecast(transform.position, ponto.position, 1 << LayerMask.NameToLayer("Floor"));
        if (podePular)
        {
            bodyControl.AddForce(Vector2.up * forcaPulo);            
        }
    }
}
