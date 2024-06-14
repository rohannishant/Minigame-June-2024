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

    public int UpdateHealth (int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        if (bar != null)
        {
            bar.UpdateHealth();
        }
        StartCoroutine(DamageRed(GetComponent<SpriteRenderer>()));
        if (health == 0)
        {
            return 1;
        }
        return 0;
    }

    IEnumerator DamageRed(SpriteRenderer render)
    {
        render.color = Color.red;
        yield return new WaitForSeconds(.25f);
        render.color = Color.white;
    }
}
