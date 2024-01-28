using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hacking : MonoBehaviour
{
    [SerializeField] List<GameObject> Shapes;
    [SerializeField] float coneAngle;
    [SerializeField] Vector2 spawnOffset;
    private static GameObject enemy;
    private static GameObject hackingScreen;
    private static GameObject player;
    private static bool hackingScreenOpen;

    private void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        player = gameObject;
        hackingScreen = gameObject.transform.parent.gameObject;
    }
    private void Update()
    {
        if (FlagManager.isHacking && !Chatbox.IsActive())
        {
            FlipHackingScreen(true);
        }

        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Return) && hackingScreenOpen && enemy != null)
        {
        
            Vector3 spawnPosition = this.transform.position + new Vector3(spawnOffset.x, spawnOffset.y, 0f);
            Vector3 directionToEnemy = (enemy.transform.position - spawnPosition).normalized;

            int selectedShape;
            int randomShape = Random.Range(0, 11);
            if (randomShape <= 4)
            {
                selectedShape = 0;
            }
            else if (randomShape <= 9)
            {
                selectedShape = 1;
            }
            else
            {
                selectedShape = 2;
            }

            //new direction with the number spread
            float angle = Random.Range(-coneAngle / 2, coneAngle / 2);
            Vector3 coneDirection = Quaternion.Euler(0, 0, angle) * directionToEnemy;

            //Instanciate and give direction 
            GameObject shapeInstance = Instantiate(Shapes[selectedShape], spawnPosition, Quaternion.identity);
            shapeInstance.GetComponent<HackingLetters>().SetDirection(coneDirection);
        }
    }

    public static void FlipHackingScreen(bool active)
    {
        enemy.GetComponent<SpriteRenderer>().enabled = active;
        hackingScreenOpen = active;
        hackingScreen.GetComponent<SpriteRenderer>().enabled = active;
        player.GetComponent<SpriteRenderer>().enabled = active;
        FlagManager.isHacking = active;
        if (!active)
        {
            if (!FlagManager.canDigitize)
            {
                string text = System.IO.File.ReadAllText("Assets/Text/FirstHackVictory.txt");
                ChatManager.ProcessText(text);
                FlagManager.canDigitize = true;
            }
            else if (FlagManager.usedImportantFile && !FlagManager.askedCloneForHelp)
            {
                string text = System.IO.File.ReadAllText("Assets/Text/SecondHackFail.txt");
                ChatManager.ProcessText(text);
            }
            else if (!FlagManager.completedSecondHack)
            {
                string text = System.IO.File.ReadAllText("Assets/Text/SecondHackVictory.txt");
                ComputerUIManager.FlipDesktopUI(false);
                FlagManager.completedSecondHack = true;
                ChatManager.ProcessText(text);
            }
        }
    }
}
