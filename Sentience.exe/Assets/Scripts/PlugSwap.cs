using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugSwap : MonoBehaviour
{
    [SerializeField] Sprite serializedUnplugged;
    [SerializeField] SpriteRenderer serializedPlugSprite;

    private static Sprite unplugged;
    private static SpriteRenderer plugSprite;

    private void Start()
    {
        unplugged = serializedUnplugged;
        plugSprite = serializedPlugSprite;
    }

    public static void UnplugPlugSprite()
    {
        plugSprite.sprite = unplugged;
    }
}
