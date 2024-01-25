using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> slideBlocks;
    [SerializeField] private GameObject slideBlock;

    private static int dimensions = 5;
    private static SlideBlock slideBlockComponent;
    private static bool solved = false;
    private bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (open)
            {
                foreach (GameObject block in slideBlocks)
                {
                    block.GetComponent<SpriteRenderer>().enabled = false;
                    block.GetComponent<BoxCollider2D>().enabled = false;
                    open = false;
                } 
            }
            else
            {
                foreach (GameObject block in slideBlocks)
                { 
                    block.GetComponent<SpriteRenderer>().enabled = true;
                    block.GetComponent<BoxCollider2D>().enabled = true;
                    open = true;
                }
            }
        }
    }
}
