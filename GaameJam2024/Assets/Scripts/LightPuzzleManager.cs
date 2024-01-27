using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class LightPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject lightBox;

    private static int dimensions = 5;
    private static Lights lightComponent;
    private static List<List<GameObject>> lights;
    private static int activeCount = 0;
    private static bool solved = false;
    private bool created = false;
    private bool open = false;

    void Start()
    {
        lights = new List<List<GameObject>>();
    }

    private void Update()
    {
        if (created && !ComputerUIManager.activeUI)
        {
            foreach (List<GameObject> row in lights)
            {
                foreach (GameObject light in row)
                {
                    light.GetComponent<SpriteRenderer>().enabled = false;
                    light.GetComponent<BoxCollider2D>().enabled = false;
                    open = false;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && FlagManager.foundEncryptionKey)
        {
            if (!created)
            {
                CreatePuzzle();
            }
            else if (open)
            {
                foreach (List<GameObject> row in lights)
                {
                    foreach (GameObject light in row)
                    {
                        light.GetComponent<SpriteRenderer>().enabled = false;
                        light.GetComponent<BoxCollider2D>().enabled = false;
                        open = false;
                    }
                }
            }
            else
            {
                foreach (List<GameObject> row in lights)
                {
                    foreach (GameObject light in row)
                    {
                        light.GetComponent<SpriteRenderer>().enabled = true;
                        light.GetComponent<BoxCollider2D>().enabled = true;
                        open = true;
                    }
                }
            }
        }
    }

    private void CreatePuzzle()
    {
        for (int y = 0; y < dimensions; ++y)
        {
            List<GameObject> row = new List<GameObject>();
            for (int x = 0; x < dimensions; ++x)
            {
                float xPos = gameObject.transform.position.x + x + lightBox.GetComponent<SpriteRenderer>().size.x;
                float yPos = gameObject.transform.position.y - y - lightBox.GetComponent<SpriteRenderer>().size.y;
                GameObject toAdd = Instantiate(lightBox, new Vector3(xPos, yPos, 0), Quaternion.identity);
                Lights lightComponent = toAdd.GetComponent<Lights>();
                lightComponent.SetIndex(x, y);
                row.Add(toAdd);
            }
            lights.Add(row);
        }
        created = true;
        open = true;
    }

    public static bool GetSolved()
    {
        return solved;
    }

    public static void FlipLights(Lights light)
    {
        light.FlipActive();
        int xIndex = light.GetIndex().x;
        int yIndex = light.GetIndex().y;


        if (xIndex - 1 >= 0)
        {
            lightComponent = lights[yIndex][xIndex - 1].GetComponent<Lights>();
            lightComponent.FlipActive();
        }
        if (xIndex + 1 < dimensions)
        {
            lightComponent = lights[yIndex][xIndex + 1].GetComponent<Lights>();
            lightComponent.FlipActive();
        }
        if (yIndex - 1 >= 0)
        {
            lightComponent = lights[yIndex - 1][xIndex].GetComponent<Lights>();
            lightComponent.FlipActive();
        }
        if (yIndex + 1 < dimensions)
        {
            lightComponent = lights[yIndex + 1][xIndex].GetComponent<Lights>();
            lightComponent.FlipActive();
        }
        if (activeCount >= dimensions * dimensions)
        {
            solved = true;
        }
        if (solved)
        {
            foreach (List<GameObject> row in lights)
            {
                foreach (GameObject toCheck in row)
                {
                    toCheck.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            FlagManager.disabledFirewall = true;
        }
    }

    public static void IncrementActiveCount(bool increment)
    {
        if (increment)
        {
            ++activeCount;
            return;
        }
        --activeCount;
    }
}
