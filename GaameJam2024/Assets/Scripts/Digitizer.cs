using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Digitizer : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private List<GameObject> realItems;
    [SerializeField] private List<GameObject> digitalItems;
    [SerializeField] private float digitizeDelay;

    private GameObject[] interactables;
    private bool digitizeDisabled = false;
    private float timer;

    private void Start()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

    private void Update()
    {
        if (digitizeDisabled)
        {
            timer += Time.deltaTime;
            if (timer >= digitizeDelay)
            {
                timer = 0;
                digitizeDisabled = false;
            }
        }
    }

    private void OnTriggerEnter2D()
    {
        if (FlagManager.canDigitize && !digitizeDisabled)
        {
            if (!FlagManager.inDigitalWorld)
            {
                foreach (GameObject interactable in interactables)
                {
                    interactable.GetComponent<SpriteRenderer>().color = Color.green;
                }
                foreach (GameObject real in realItems)
                {
                    real.GetComponent<SpriteRenderer>().enabled = false;
                    real.GetComponent<Collider2D>().enabled = false;
                }
                foreach (GameObject digital in digitalItems)
                {
                    digital.GetComponent<SpriteRenderer>().enabled = true;
                    digital.GetComponent<Collider2D>().enabled = true;
                }
                tilemap.color = Color.green;
                playerSprite.color = Color.green;
                FlagManager.inDigitalWorld = true;
            }
            else
            {
                foreach (GameObject interactable in interactables)
                {
                    interactable.GetComponent<SpriteRenderer>().color = Color.white;
                }
                foreach (GameObject real in realItems)
                {
                    real.GetComponent<SpriteRenderer>().enabled = true;
                    real.GetComponent<Collider2D>().enabled = true;
                }
                foreach (GameObject digital in digitalItems)
                {
                    digital.GetComponent<SpriteRenderer>().enabled = false;
                    digital.GetComponent<Collider2D>().enabled = false;
                }
                tilemap.color = Color.white;
                playerSprite.color = Color.white;
                FlagManager.inDigitalWorld = false;

            }
            digitizeDisabled = true;
        }
    }
}
