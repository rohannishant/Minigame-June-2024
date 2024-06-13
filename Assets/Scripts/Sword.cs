using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    int swordKnockback;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null && collision.gameObject.GetComponent<Player>() == null)
        {
            health.UpdateHealth(-damage);
            if(collision.gameObject.name == "skeleton_0(Clone)")
            {
                Debug.Log("lets go");
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                Vector2 location = new Vector2(transform.position.x, transform.position.y);
                Vector2 knockbackDirection = (rb.position - location).normalized;
                rb.AddForce(knockbackDirection * swordKnockback, ForceMode2D.Impulse);
            }
        }
    }
}
