using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPrincipalNivel3 : MonoBehaviour
{
    private Rigidbody2D body;
    private float speed = 4;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //Se obtienen las referencias para obtener el RigidBody2D y el animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //Se obtiene que flecha presiona el juagdor

        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //Cambiar el personaje de direccion
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(3, 3, 3);

        }else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-3, 3, 3);

        }

        //Salto
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }

        //Se establecen los parametros del Animator
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, 10);
        anim.SetTrigger("jump");
        grounded = false;

    }

    //Detectar colsiones de dos objetos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
