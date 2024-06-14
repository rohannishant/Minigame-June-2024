using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image border, background, hp;

    Health health;

    [SerializeField]
    Color healthy, critical;

    void Start()
    {
        health = GetComponentInParent<Health>();
        health.bar = this;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (health.HealthAmount == health.MaxHealth)
        {
            border.enabled = false;
            background.enabled = false;
            hp.enabled = false;
        }
        else
        {
            border.enabled = true;
            background.enabled = true;
            hp.enabled = true;
            hp.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, .45f * health.HealthAmount / health.MaxHealth);
            hp.color = health.HealthAmount < health.MaxHealth / 4f ? critical : healthy;
        }
    }
}
