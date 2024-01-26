using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hacking : MonoBehaviour
{
    [SerializeField] List<GameObject> Shapes;
    [SerializeField] float coneAngle;
    [SerializeField] Vector2 spawnOffset;
    private bool isHacking = true;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").transform.gameObject;
    }
    private void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Return) && isHacking)
        {
            Vector3 spawnPosition = this.transform.position + new Vector3(spawnOffset.x, spawnOffset.y, 0f);
            Vector3 directionToEnemy = (enemy.transform.position - spawnPosition).normalized;

            foreach (GameObject shapePrefab in Shapes)
            {
               //new direction with the number spread
                float angle = Random.Range(-coneAngle / 2, coneAngle / 2);
                Vector3 coneDirection = Quaternion.Euler(0, 0, angle) * directionToEnemy;

                //Instanciate and give direction 
                GameObject shapeInstance = Instantiate(shapePrefab, spawnPosition, Quaternion.identity);
                shapeInstance.GetComponent<HackingLetters>().SetDirection(coneDirection);
            }
        }
    }
}
