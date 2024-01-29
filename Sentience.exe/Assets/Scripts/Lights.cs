using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private bool active;
    private SpriteRenderer lightSprite;
    private Lights lightComponent;
    private int xPos, yPos;

    private void Start()
    {
        lightSprite = gameObject.GetComponent<SpriteRenderer>();
        lightComponent = gameObject.GetComponent<Lights>();
        lightSprite.color = Color.gray;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !LightPuzzleManager.GetSolved())
        {
            LightPuzzleManager.FlipLights(lightComponent);
        }
    }

    public void FlipActive()
    {
        if (active)
        {
            active = false;
            lightSprite.color = Color.gray;
            LightPuzzleManager.IncrementActiveCount(false);
        }
        else
        {
            active = true;
            lightSprite.color = Color.yellow;
            LightPuzzleManager.IncrementActiveCount(true);
        }
    }

    public bool GetActive()
    {
        return active;
    }

    public void SetIndex(int x, int y)
    {
        xPos = x;
        yPos = y;
    }
    
    public Vector2Int GetIndex()
    {
        return new Vector2Int(xPos, yPos);
    }
}
