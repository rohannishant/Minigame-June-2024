using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int health, maxHealth;

    public int HealthAmount { get { return health; } }
    public int MaxHealth {  get { return maxHealth; } }

    public HealthBar bar = null;

    public void UpdateHealth (int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        if (bar != null)
        {
            bar.UpdateHealth();
        }
        StartCoroutine(DamageRed(GetComponent<SpriteRenderer>()));
    }

    IEnumerator DamageRed(SpriteRenderer render)
    {
        render.color = Color.red;
        yield return new WaitForSeconds(.25f);
        render.color = Color.white;
    }
}
