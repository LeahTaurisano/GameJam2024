using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFirewall : MonoBehaviour
{
    void Update()
    {
        if (FlagManager.disabledFirewall)
        {
            Destroy(gameObject);
        }
    }
}
