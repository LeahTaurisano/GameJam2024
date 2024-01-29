using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{
    [SerializeField] Vector3 cameraStartPositionSerialized;
    [SerializeField] Vector3 cameraUIPositionSerialized;
    [SerializeField] GameObject serializedCamera;

    private static GameObject mainCamera;
    private static Vector3 cameraStartPosition;
    private static Vector3 cameraUIPosition;
    public static bool activeUI = false;

    private void Start()
    {
        cameraStartPosition = cameraStartPositionSerialized;
        cameraUIPosition = cameraUIPositionSerialized;
        mainCamera = serializedCamera;
    }

    public static void FlipDesktopUI(bool active)
    {
        if (active)
        {
            mainCamera.transform.position = cameraUIPosition;
        }
        else
        {
            mainCamera.transform.position = cameraStartPosition;
        }
        activeUI = active;
    }

}