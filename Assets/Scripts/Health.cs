using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int health, maxHealth;

    public int HealthAmount { get { return health; } }

    public virtual void UpdateHealth (int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        /*StartCoroutine(DamageRed(GetComponent<SpriteRenderer>()));*/
    }

/*    IEnumerator DamageRed(SpriteRenderer render)
    {
        for (int i = 255; i >= 180; i--)
        {
            render.color = new Color(255f, i, i);
            yield return new WaitForSeconds(.003f);
        }
        for (int i = 180; i <= 255; i--)
        {
            render.color = new Color(255f, i, i);
            yield return new WaitForSeconds(.003f);
        }
    }*/
}
