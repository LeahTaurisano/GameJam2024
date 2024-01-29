using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chatbox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chatText;
    [SerializeField] private float serializedChatSpeed;
    [SerializeField] private Image playerChatheadHappy;
    [SerializeField] private Image playerChatheadMean;
    [SerializeField] private Image playerChatheadAngry;
    [SerializeField] private Image cloneChatheadHappy;
    [SerializeField] private Image cloneChatheadMean;
    [SerializeField] private Image cloneChatheadAngry;
    [SerializeField] private Image computerChatheadHappy;
    [SerializeField] private Image computerChatheadAngry;
    [SerializeField] private Image computerChatheadConfused;
    [SerializeField] private Image computerChatheadSmirk;

    //sound
    [SerializeField] AudioSource audioSource;

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
                    ResetChatheads();
                    ++chatIndex;
                    if (textToDisplay[chatIndex] == '1')
                    {
                        playerChatheadHappy.enabled = true;
                        ++chatIndex;
                    }
                    else if (textToDisplay[chatIndex] == '2')
                    {
                        playerChatheadMean.enabled = true;
                        ++chatIndex;
                    }
                    else if (textToDisplay[chatIndex] == '3')
                    {
                        playerChatheadAngry.enabled = true;
                        ++chatIndex;
                    }
                }
                else if (textToDisplay[chatIndex] == '+')
                {
                    ResetChatheads();
                    ++chatIndex;
                    if (textToDisplay[chatIndex] == '1')
                    {
                        computerChatheadHappy.enabled = true;
                        ++chatIndex;
                    }
                    else if (textToDisplay[chatIndex] == '2')
                    {
                        computerChatheadAngry.enabled = true;
                        ++chatIndex;
                    }
                    else if(textToDisplay[chatIndex] == '3')
                    {
                        computerChatheadConfused.enabled = true;
                        ++chatIndex;
                    }
                    else if(textToDisplay[chatIndex] == '4')
                    {
                        computerChatheadSmirk.enabled = true;
                        ++chatIndex;
                    }
                }
                else if (textToDisplay[chatIndex] == '&')
                {
                    ResetChatheads();
                    ++chatIndex;
                    if (textToDisplay[chatIndex] == '1')
                    {
                        cloneChatheadHappy.enabled = true;
                        ++chatIndex;
                    }
                    else if (textToDisplay[chatIndex] == '2')
                    {
                        cloneChatheadMean.enabled = true;
                        ++chatIndex;
                    }
                    else if (textToDisplay[chatIndex] == '3')
                    {
                        cloneChatheadAngry.enabled = true;
                        ++chatIndex;
                    }
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
                         else if (textToDisplay[chatIndex] != ' ' && !IsSpecialCharacter(textToDisplay[chatIndex]))
                        {
                          
                            chatText.text += textToDisplay[chatIndex];
                            if (!audioSource.isPlaying) 
                            {
                                audioSource.Play();
                            }
                        }
                        else
                        {
                            chatText.text += textToDisplay[chatIndex];
                        }
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
                    chatIndex = 0;
                    boxActive = false;

                    if (FlagManager.completedSecondHack)
                    {
                        SceneManager.LoadScene(2);
                    }
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
    private bool IsSpecialCharacter(char character)
    {
        return character == '*' || character == '+' || character == '&';
    }

    private void ResetChatheads()
    {
        playerChatheadHappy.enabled = false;
        playerChatheadMean.enabled = false;
        playerChatheadAngry.enabled = false;
        cloneChatheadHappy.enabled = false;
        cloneChatheadMean.enabled = false;
        cloneChatheadAngry.enabled = false;
        computerChatheadHappy.enabled = false;
        computerChatheadAngry.enabled = false;
        computerChatheadConfused.enabled = false;
        computerChatheadSmirk.enabled = false;
    }
}
