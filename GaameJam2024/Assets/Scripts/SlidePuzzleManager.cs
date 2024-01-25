using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> slideBlocks;
    [SerializeField] private GameObject slideBlock;
    [SerializeField] private SlideBlock emptyBlock;

    private static int dimensions = 5;
    private static bool solved = false;
    private bool open = false;
    private static int correctCount;
    private static int emptyIndex;

    private void Start()
    {
        int startPos = 0;

        foreach (GameObject block in slideBlocks)
        {
            block.GetComponent<SlideBlock>().SetIndex(startPos);
            ++startPos;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (open)
            {
                foreach (GameObject block in slideBlocks)
                {
                    if (!block.GetComponent<SlideBlock>().isEmpty)
                    {
                        block.GetComponent<SpriteRenderer>().enabled = false;
                        block.GetComponent<BoxCollider2D>().enabled = false;
                        open = false;
                    }
                } 
            }
            else
            {
                foreach (GameObject block in slideBlocks)
                {
                    if (!block.GetComponent<SlideBlock>().isEmpty)
                    {
                        block.GetComponent<SpriteRenderer>().enabled = true;
                        block.GetComponent<BoxCollider2D>().enabled = true;
                        open = true;
                    }
                }
            }
        }
    }

    private void Update()
    {
        emptyIndex = emptyBlock.GetIndex();
    }

    public static bool GetSolved()
    {
        return solved;
    }

    public static void IncrementCorrectCount(bool correct)
    {
        if (correct)
        {
            ++correctCount;
            return;
        }
        --correctCount;
    }

    public static void SwapBlocks(SlideBlock block)
    {

        int currentPos = block.GetIndex();

        if (emptyIndex == currentPos + dimensions || emptyIndex == currentPos - dimensions || emptyIndex == currentPos - 1 || emptyIndex == currentPos + 1)
        {
            block.Swap();
        }
        
        if (correctCount >= dimensions * dimensions)
        {
            solved = true;
        }
        if (solved)
        {
            //solved things
        }
    }
}
