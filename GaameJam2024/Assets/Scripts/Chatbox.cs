using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chatbox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chatText;
    [SerializeField] private float serializedChatSpeed;
    [SerializeField] private Image playerChathead;
    [SerializeField] private Image cloneChathead;
    [SerializeField] private Image computerChathead;

    private Canvas chatCanvas;
    private int chatIndex = 0;
    private static string textToDisplay;
    private static bool boxActive = false;
    private static float chatSpeed;
    private float timer = 0;
    private bool textWaiting = false;
    // Start is called before the first frame update
    void Start()
    {
        chatSpeed = serializedChatSpeed;
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
                if (textToDisplay[chatIndex] == '*')
                {
                    playerChathead.enabled = true;
                    cloneChathead.enabled = false;
                    computerChathead.enabled = false;
                    ++chatIndex;
                }
                else if (textToDisplay[chatIndex] == '+')
                {
                    playerChathead.enabled = false;
                    cloneChathead.enabled = false;
                    computerChathead.enabled = true;
                    ++chatIndex;
                }
                else if (textToDisplay[chatIndex] == '&')
                {
                    playerChathead.enabled = false;
                    cloneChathead.enabled = true;
                    computerChathead.enabled = false;
                    ++chatIndex;
                }
                timer += Time.deltaTime;
                if (timer >= chatSpeed)
                {
                    if (textToDisplay[chatIndex] == '/')
                    {
                        textWaiting = true;
                    }
                    else
                    {
                        if (textToDisplay[chatIndex] == '~')
                        {
                            chatText.text += "\n";
                            ++chatIndex;
                        }
                        chatText.text += textToDisplay[chatIndex];
                    }
                    ++chatIndex;
                    timer = 0;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                textWaiting = false;
                chatText.text = "";
                if (textToDisplay[chatIndex] == '|')
                {
                    playerChathead.enabled = false;
                    cloneChathead.enabled = false;
                    computerChathead.enabled = false;
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
