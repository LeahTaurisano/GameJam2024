using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private float rangeCheckRadius;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera worldCamera;


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !Chatbox.IsActive())
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
}
