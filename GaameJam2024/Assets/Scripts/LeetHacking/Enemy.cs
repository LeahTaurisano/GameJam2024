using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HackingLetters bullet = collision.gameObject.GetComponent<HackingLetters>();
        if (bullet != null)
        {
            TakeDamage(bullet.GetDamage()); 
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) 
        {
            GameObject[] hackingNumbers = GameObject.FindGameObjectsWithTag("HackingNumbers"); ;
            foreach (GameObject number in hackingNumbers)
            {
                Destroy(number);
            }
            Hacking.FlipHackingScreen(false);
            health = 100;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
