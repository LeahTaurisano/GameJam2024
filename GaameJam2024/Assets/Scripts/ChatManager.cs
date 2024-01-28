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
        ProcessText("*1Ahh, another day... Plenty of work to do, I'd better head over to my computer!/|");
    }

    public static bool CheckInRange(float rangeCheckRadius)
    {
        Vector3 mousePos = worldCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 10;

        if (Vector3.Distance(mousePos, player.transform.position) <= rangeCheckRadius)
        {
            return true;
        }

        return false;
    }

    public static void ProcessText(string text)
    {
        Chatbox.SetText(text);
        Chatbox.SetActive(true);
    }
}
