using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HackingLetters : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damage;
    private Vector2 direction;
    [SerializeField] float destroyTime;
    float destroyTimer;


    public int GetDamage ( ) { return damage; }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; 
    }

    void FixedUpdate()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer >= destroyTime) 
        {
           Destroy(gameObject);
        }
        rb.velocity = direction * speed; 
    }
}
