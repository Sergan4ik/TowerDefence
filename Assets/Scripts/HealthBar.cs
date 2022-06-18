using System;
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

    public void SetHealth(float amount , float maxAmount) => SetHealth(amount / maxAmount);

    public void SetHealth(float normalizedHealth)
    {
        if (normalizedHealth > 1f || normalizedHealth < 0)
            throw new ArgumentException($"Health isn't valid , current normalized health is: {normalizedHealth}");
        bar.fillAmount = normalizedHealth;
    }
}