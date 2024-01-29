using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> slideBlocks;
    [SerializeField] private SlideBlock emptyBlock;
    [SerializeField] private GameObject firewall;

    private GameObject[] interactables;
    private static int dimensions = 5;
    private static bool solved = false;
    private bool open = false;
    private static int emptyIndex;

    private void Start()
    {
        int startPos = 0;

        foreach (GameObject block in slideBlocks)
        {
            block.GetComponent<SlideBlock>().SetIndex(startPos);
            ++startPos;
        }
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && FlagManager.disabledFirewall)
        {
            TogglePuzzle();
        }
    }

    private void Update()
    {
        if (open && !solved)
        {
            emptyIndex = emptyBlock.GetIndex();
            CheckSolved();
        }
        if (open && !FlagManager.inDigitalWorld)
        {
            TogglePuzzle();
        }
    }

    public static bool GetSolved()
    {
        return solved;
    }

    private void CheckSolved()
    {
        int numCorrect = 0;
        foreach (GameObject block in slideBlocks)
        {
            SlideBlock component = block.GetComponent<SlideBlock>();
            if (component.IsCorrect())
            {
                ++numCorrect;
            }
            else
            {
                --numCorrect;
            }
        }
        if (numCorrect >= dimensions * dimensions || FlagManager.devMode)
        {
            solved = true;
            TogglePuzzle();
            FlagManager.foundImportantFile = true;
            UnityEngine.TextAsset textAsset = (UnityEngine.TextAsset)Resources.Load("FileObtained");
            string text = textAsset.text;
            ChatManager.ProcessText(text);
        }
    }

    private void TogglePuzzle()
    {
        if (!FlagManager.foundImportantFile)
        {
            if (open)
            {
                foreach (GameObject block in slideBlocks)
                {
                    if (!block.GetComponent<SlideBlock>().isEmpty)
                    {
                        block.GetComponent<SpriteRenderer>().enabled = false;
                        block.GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
                open = false;
                FlagManager.slidePuzzleOpen = false;
                foreach (GameObject interactable in interactables)
                {
                    if (interactable != firewall)
                    {
                        interactable.GetComponent<Collider2D>().enabled = true;
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
                    }
                }
                open = true;
                FlagManager.slidePuzzleOpen = true;
                foreach (GameObject interactable in interactables)
                {
                    interactable.GetComponent<Collider2D>().enabled = false;
                }
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    public static void SwapBlocks(SlideBlock block)
    {

        int currentPos = block.GetIndex();

        if (emptyIndex == currentPos + dimensions || emptyIndex == currentPos - dimensions)
        {
            block.Swap();
        }
        else if (emptyIndex == currentPos - 1 && currentPos != 5 && currentPos != 10 && currentPos != 15 && currentPos != 20)
        {
            block.Swap();
        }
        else if (emptyIndex == currentPos + 1 && currentPos != 4 && currentPos != 9 && currentPos != 14 && currentPos != 19)
        {
            block.Swap();
        }
    }
}
