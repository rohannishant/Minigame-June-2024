using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null && collision.gameObject.GetComponent<Player>() == null)
        {
            health.UpdateHealth(-damage);
        }
    }
}
