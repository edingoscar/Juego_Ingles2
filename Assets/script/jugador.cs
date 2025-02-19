using System;
using UnityEngine;

public class jugador : MonoBehaviour
{
    private Rigidbody2D rgb2d;
    private Animator animator;
    public float velocidad = 5f;
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        rgb2d.linearVelocity = new Vector2(directionX, directionY).normalized * velocidad;

        animator.SetFloat("Velocidad", rgb2d.linearVelocity.magnitude/velocidad);

        if(rgb2d.linearVelocityY < 0){
            animator.SetInteger("Direccion", 0);
        }else if(rgb2d.linearVelocityY > 0){
            animator.SetInteger("Direccion", 1);
        }else if(rgb2d.linearVelocityX>0){
            animator.SetInteger("Direccion", 2);
        }else if(rgb2d.linearVelocityX<0){
            animator.SetInteger("Direccion", 3);
        }
    }
}
