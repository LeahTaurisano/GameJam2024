using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Animate(movement); 
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    /* void Animate(Vector2 direction)
     {
         if (direction != Vector2.zero)
         {
             animator.SetFloat("Horizontal", direction.x);
             animator.SetFloat("Vertical", direction.y);
             animator.SetBool("isWalking", true);
         }
         else if(movement != Vector2.zero) 
         {
             animator.SetBool("isWalking", false);
             animator.SetBool("idle", true);
            
         }
     }*/

}
