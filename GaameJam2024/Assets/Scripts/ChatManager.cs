using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    [SerializeField] GameObject serializedPlayer;
    [SerializeField] Camera serializedCamera;

    private static GameObject player;
    private static Camera worldCamera;

    private void Start()
    {
        player = serializedPlayer;
        worldCamera = serializedCamera;
    }

    //public static bool CheckRange(float rangeCheckRadius)
    //{
    //    Vector3 mousePos = worldCamera.ScreenToWorldPoint(Input.mousePosition);
    //    mousePos.z += 10;

    //    if (Vector3.Distance(mousePos, player.transform.position) <= rangeCheckRadius)
    //    {
    //        Chatbox.SetText(text);
    //    }
    //}

    public static void ProcessText(string text, float rangeCheckRadius)
    {
        Vector3 mousePos = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 10;

        if (Vector3.Distance(mousePos, player.transform.position) <= rangeCheckRadius)
        {
            Chatbox.SetText(text);
        }
        else
        {
            Chatbox.SetText("I need to get closer to check that./|");
        }
        Chatbox.SetActive(true);
    }
}
