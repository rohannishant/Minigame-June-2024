using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Pathfinding;

public class Sword : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    float swordKnockback;
    [SerializeField]
    float aiDisableDelay;

    [SerializeField]
    CircleCollider2D swordRadius;

    Animator animator;
    int isEnemyDead = 0;

    float timer = 0f;
    [SerializeField]
    float attackRate;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timer = Mathf.Max(timer - Time.deltaTime, 0f);

        if (Input.GetMouseButtonDown(0) && timer == 0f)
        {
            timer = attackRate;

            animator.SetTrigger("attack");
            List<Collider2D> colliders = new List<Collider2D>();
            swordRadius.OverlapCollider(new ContactFilter2D().NoFilter(), colliders);
            foreach (Chest chest in colliders.Where(collider => collider.GetComponent<Chest>() != null)
                .Select(collider => collider.GetComponent<Chest>()))
            {
                chest.Open();
            }
            foreach (Health health in colliders.Select(collider => collider.GetComponent<Health>())
                .Where(health => health != null && health.GetComponent<Player>() == null))
            {
                isEnemyDead = health.UpdateHealth(-damage);
                Rigidbody2D rb = health.GetComponent<Rigidbody2D>();
                Vector2 playerPos = new Vector2(transform.parent.position.x, transform.parent.position.y);
                Vector2 knockbackDirection = (rb.position - playerPos).normalized;
                StartCoroutine(KnockBackForce(rb, knockbackDirection * swordKnockback));
                if(isEnemyDead == 1)
                {
                    Destroy(health.gameObject);
                }
            }
        }
    }

    IEnumerator KnockBackForce(Rigidbody2D rb, Vector2 force)
    {
        AIPath ai = rb.GetComponent<AIPath>();
        ai.canMove = false;
        rb.AddForce(force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(aiDisableDelay);
        ai.canMove = true;
    }
}
