using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class FullscreenTestController : MonoBehaviour
{
    [Header("Toggle")]
    //[SerializeField] private bool _active = false;


    [Header("Time Stats")]
    //[SerializeField] private float _matrixFadeInTime = 1.0f;
    [SerializeField] private float _matrixFadeOutTime = 5.5f;


    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _matrixEffect;
    [SerializeField] private Material _material;

    private int _alphaIntensity = Shader.PropertyToID("_AlphaFade");

    private const float _alphaStart = 0.0f;
    private const float _alphaEnd = 1.0f;

    //private float iterate = 0.0f;

    private void Start()
    {
        _matrixEffect.SetActive(false);
    }

    private void Update()
    {
        if (FlagManager.inDigitalWorld && !_matrixEffect.isActive)
        {
            StartCoroutine(Transition());
        }
        else if (!FlagManager.inDigitalWorld && _matrixEffect.isActive)
        {
            StartCoroutine(TransitionOut());
        }
    }

    private IEnumerator Transition()
    {
        _matrixEffect.SetActive(true);
        _material.SetFloat(_alphaIntensity, _alphaStart);

        yield return new WaitForSeconds(_matrixFadeOutTime);

        float elapsedTime = 0f;
        while (elapsedTime < _matrixFadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedAlpha = Mathf.Lerp(_alphaStart, _alphaEnd, (elapsedTime / _matrixFadeOutTime));

            _material.SetFloat(_alphaIntensity, lerpedAlpha);

            yield return null;
        }
        //_matrixEffect.SetActive(false);
    }

    private IEnumerator TransitionOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < _matrixFadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            float lerpedAlpha = Mathf.Lerp(_alphaEnd, _alphaStart, (elapsedTime / _matrixFadeOutTime));

            _material.SetFloat(_alphaIntensity, lerpedAlpha);

            yield return null;
        }
        _matrixEffect.SetActive(false);
    }
}
