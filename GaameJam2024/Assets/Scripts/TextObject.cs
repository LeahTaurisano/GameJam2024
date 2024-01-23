using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private string text;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!Chatbox.IsActive())
            {
                Chatbox.SetText(text);
                Chatbox.SetActive(true);
            }
        }
    }
}
