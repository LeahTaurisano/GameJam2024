using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chatbox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chatText;

    private Canvas chatCanvas;
    private int chatIndex = 0;
    private static string textToDisplay;
    private static bool boxActive = false;
    private static float chatSpeed = 0.05f;
    private float timer = 0;
    private bool textWaiting = false;
    // Start is called before the first frame update
    void Start()
    {
        chatCanvas = gameObject.GetComponent<Canvas>();
        chatCanvas.enabled = boxActive;
        chatText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        chatCanvas.enabled = boxActive;
        if (chatCanvas.enabled)
        {
            if (!textWaiting)
            {
                timer += Time.deltaTime;
                if (timer >= chatSpeed)
                {
                    if (textToDisplay[chatIndex] == '/')
                    {
                        textWaiting = true;
                    }
                    else
                    {
                        chatText.text += textToDisplay[chatIndex];
                    }
                    ++chatIndex;
                    timer = 0;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                textWaiting = false;
                chatText.text = "";
                if (textToDisplay[chatIndex] == '|')
                {
                    chatIndex = 0;
                    boxActive = false;
                }
            }
        }
    }

    public static void SetActive(bool state)
    {
        boxActive = state;
    }

    public static bool IsActive()
    {
        return boxActive;
    }    

    public static void SetText(string text)
    {
        textToDisplay = text;
    }
}
