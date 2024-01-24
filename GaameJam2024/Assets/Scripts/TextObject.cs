using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private string text;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !Chatbox.IsActive())
        {
            Chatbox.SetText(text);
            Chatbox.SetActive(true);
        }
    }
}
