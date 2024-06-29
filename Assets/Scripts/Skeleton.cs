using UnityEngine;
using Pathfinding;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    bool useAI;
    [SerializeField]
    float knockback;

    [SerializeField]
    float viewDistance;

    Transform player;
    Animator animator;
    AIDestinationSetter dest;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        dest = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useAI && (transform.position - player.position).magnitude <= viewDistance)
        {
            dest.target = player;
        }
        else if (useAI)
        {
            dest.target = null;
        }

        animator.SetBool("moving", dest.target != null);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.UpdateHealth(-1);
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            Vector2 skeletonLocation = new Vector2(transform.position.x, transform.position.y);
            Vector2 knockbackDirection = (rb.position - skeletonLocation).normalized;
            rb.AddForce(knockbackDirection * knockback, ForceMode2D.Impulse);
        }
    }
    
}
