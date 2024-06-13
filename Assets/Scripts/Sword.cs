using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sword : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    float swordKnockback;

    [SerializeField]
    CircleCollider2D swordRadius;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            List<Collider2D> colliders = new List<Collider2D>();
            swordRadius.OverlapCollider(new ContactFilter2D().NoFilter(), colliders);
            foreach (Health health in colliders.Select(collider => collider.GetComponent<Health>()).Where(health => health != null && health.GetComponent<Player>() == null))
            {
                health.UpdateHealth(-damage);
                Rigidbody2D rb = health.GetComponent<Rigidbody2D>();
                Vector2 playerPos = new Vector2(transform.parent.position.x, transform.parent.position.y);
                Vector2 knockbackDirection = (rb.position - playerPos).normalized;
                rb.AddForce(knockbackDirection * swordKnockback, ForceMode2D.Impulse);
            }
        }
    }
}
