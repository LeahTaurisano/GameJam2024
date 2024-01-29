using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenuController : MonoBehaviour
{
    [SerializeField] Canvas PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                PauseMenu.enabled = true;
                Time.timeScale = 0;
            }
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        PauseMenu.enabled = false;
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
