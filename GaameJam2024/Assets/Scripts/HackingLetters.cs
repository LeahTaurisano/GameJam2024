using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingLetters : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 10);
    }

    private void Update()
    {
        if (transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
