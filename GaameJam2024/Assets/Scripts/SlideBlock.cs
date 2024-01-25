using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBlock : MonoBehaviour
{
    [SerializeField] private int correctPos;
    [SerializeField] private GameObject emptyBlock;
    [SerializeField] private SlideBlock emptyBlockComponent;
    [SerializeField] public bool isEmpty;

    private bool inPosition;
    public int currentPos;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !SlidePuzzleManager.GetSolved() && !isEmpty)
        {
            SlidePuzzleManager.SwapBlocks(this);
        }
    }

    public void Swap()
    {
        int tempIndex = currentPos;
        currentPos = emptyBlockComponent.GetIndex();
        emptyBlockComponent.SetIndex(tempIndex);

        Vector3 tempPosition = gameObject.transform.position;
        gameObject.transform.position = emptyBlock.transform.position;
        emptyBlock.transform.position = tempPosition;

        if (currentPos == correctPos)
        {
            inPosition = true;
        }
    }

    public bool IsCorrect()
    {
        return inPosition;
    }

    public int GetIndex()
    {
        return currentPos;
    }

    public void SetIndex(int index)
    {
        currentPos = index;
    }
}
