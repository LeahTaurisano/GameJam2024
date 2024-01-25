using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBlock : MonoBehaviour
{
    [SerializeField] private Vector2Int correctPos;

    private bool inPosition;
    private SpriteRenderer blockSprite;
    private SlideBlock blockComponent;
    private int xPos, yPos;

    void Start()
    {
        blockSprite = gameObject.GetComponent<SpriteRenderer>();
        blockComponent = gameObject.GetComponent<SlideBlock>();
    }

    public void SetIndex(int x, int y)
    {
        xPos = x;
        yPos = y;
    }

    public bool IsCorrect()
    {
        return inPosition;
    }

    public Vector2Int GetIndex()
    {
        return new Vector2Int(xPos, yPos);
    }

    public void SetCorrectPosition(Vector2Int position)
    {
        correctPos = position;
    }
}
