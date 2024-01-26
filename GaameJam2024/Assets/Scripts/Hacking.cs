using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hacking : MonoBehaviour
{
    [SerializeField] List<GameObject> Shapes;

    private bool isHacking = false;

    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Return) && isHacking)
        {
            Instantiate(Shapes[Random.Range(0, Shapes.Count)], new Vector3(Random.Range(-10.0f, 10.0f), -5, 0), Quaternion.identity);
        }
    }
}
