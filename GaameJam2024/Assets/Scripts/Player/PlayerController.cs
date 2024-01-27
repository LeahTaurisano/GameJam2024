using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    private Vector2 movement;
 

    // Animation
   private Animator animator;
    private float idleTimer = 0.0f;
    private float idleDelay = 0.2f; // Delay before switching to idle

    //states for animation
    private const string PLAYER_WALK_DOWN = "WalkDown";
    private const string PLAYER_WALK_UP = "WalkUp";
    private const string PLAYER_WALK_SIDE = "WalkSide";
    private const string PLAYER_IDLE_DOWN = "DownIdle";
    private const string PLAYER_IDLE_UP = "UpIdle";
    private const string PLAYER_IDLE_SIDE = "SideIdle";

    private string currentState;
    private bool facingRight = true;

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

        if (movement.magnitude > 0)
        {
            //of moving reset timer update facing dir
            idleTimer = idleDelay;
            facingRight = moveHorizontal > 0;
        }
        else
        {
            //if not moving star timer
            idleTimer -= Time.deltaTime;
        }

        UpdateAnimationState();
    }

    void FixedUpdate()
    {
        if (!ComputerUIManager.activeUI)
        {
            MoveCharacter(movement);
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void UpdateAnimationState()
    {
        //movement animation
        if (movement.magnitude > 0)
        {
            if (movement.x != 0)
            {
                ChangeAnimationState(PLAYER_WALK_SIDE);
                if(facingRight)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if(!facingRight)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
               
            }
            else if (movement.y > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (movement.y < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
        }
        //idle animations
        else if (movement.magnitude <= 0 && idleTimer <= 0)
        {
            if (currentState == PLAYER_WALK_SIDE)
            {
                ChangeAnimationState(PLAYER_IDLE_SIDE);
                transform.localScale = new Vector3(facingRight ? 1 : -1, 1, 1);
            }
            else if (currentState == PLAYER_WALK_UP)
            {
                ChangeAnimationState(PLAYER_IDLE_UP);
            }
            else if (currentState == PLAYER_WALK_DOWN)
            {
                ChangeAnimationState(PLAYER_IDLE_DOWN);
            }
        }
    }
}
