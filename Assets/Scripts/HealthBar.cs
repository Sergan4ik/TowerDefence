using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    private Camera renderCamera;

    private void Awake()
    {
        renderCamera = GetComponent<Canvas>().worldCamera ??= Camera.main;
    }

    private void Update()
    {
        transform.forward = renderCamera.transform.forward;
    }

    public void SetHealth(float amount , float maxAmount)
    {
        SetHealth(amount / maxAmount);
    }

    private TweenerCore<float, float, FloatOptions> _tweenAction = null;
    public void SetHealth(float normalizedHealth)
    {
        if (normalizedHealth > 1f || normalizedHealth < 0)
            throw new ArgumentException($"Health isn't valid , current normalized health is: {normalizedHealth}");
        
        _tweenAction?.Kill();
        _tweenAction = bar.DOFillAmount(normalizedHealth, 0.3f);
    }

    private void OnDestroy()
    {
        _tweenAction?.Kill();
    }
}