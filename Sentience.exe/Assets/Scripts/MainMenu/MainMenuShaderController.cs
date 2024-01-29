using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainMenuShaderController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _matrixEffect;
    [SerializeField] private Material _material;
    [SerializeField] private float speed = 1.0f;

    private int _alphaIntensity = Shader.PropertyToID("_AlphaFade");
    // Start is called before the first frame update
    
    void Start()
    {
        _matrixEffect.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        _material.SetFloat(_alphaIntensity, Mathf.Sin(Time.time * speed));
    }
}
