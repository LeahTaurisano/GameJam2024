using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{
    private static GameObject[] interactableObjects;
    private static GameObject[] interactableUI;

    public static bool activeUI = false;

    private void Start()
    {
        interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");
        interactableUI = GameObject.FindGameObjectsWithTag("InteractableUI");
    }

    public static void FlipDesktopUI(bool active)
    {
        foreach (GameObject interactable in interactableUI)
        {
            interactable.GetComponent<SpriteRenderer>().enabled = active;
            interactable.GetComponent<Collider2D>().enabled = active;
            activeUI = active;
        }
        foreach (GameObject interactable in interactableObjects)
        {
            bool isVirtual = interactable.GetComponent<TextObject>().isVirtual;
            if (!isVirtual && !FlagManager.inDigitalWorld)
            {
                interactable.GetComponent<SpriteRenderer>().enabled = !active;
                interactable.GetComponent<Collider2D>().enabled = !active;
            }
            else if (isVirtual && FlagManager.inDigitalWorld)
            {
                interactable.GetComponent<SpriteRenderer>().enabled = !active;
                interactable.GetComponent<Collider2D>().enabled = !active;
            }
            activeUI = !active;
        }
    }

}