using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header("Puntos de Patrullaje")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform right;

    [Header("Enemigo")]
    [SerializeField] private Transform enemy;

    [Header("Parametros de movimientos")]
    [SerializeField] private float speed;
    private Vector3 initialScale;
    private bool movingLeft;

    [Header("Animacion")]
    [SerializeField]private Animator anim;

    [Header("Tiempo de espera")]
    [SerializeField] private float duracionEspera;
    private float duracionTimer;

    private void Awake()
    {
        initialScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);

            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= right.position.x)
            {
                MoveInDirection(1);

            }
            else
            {
                DirectionChange();
            }
        }
              
    }

    private void DirectionChange()
    {
        anim.SetBool("Moving", false);
        duracionTimer += Time.deltaTime;
        if(duracionTimer > duracionEspera)
        {
            movingLeft = !movingLeft;
        }
        
    }
    private void MoveInDirection(int _direction)
    {
        //Animacion
        duracionTimer = 0;
        anim.SetBool("Moving", true);
        //Hacer que el enemigo mire a los lados
        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * (_direction*-1), initialScale.y, initialScale.z);

        //Hacer que el enemigo se mueva a los lados
        enemy.position = new Vector3(enemy.position.x + (Time.deltaTime * _direction * speed),
           enemy.position.y, enemy.position.z );
    }
}
