using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame upda
   
    public void GoToLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    { 
        Application.Quit();
    }
    
}