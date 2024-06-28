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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (useAI && (transform.position - player.position).magnitude <= viewDistance)
        {
            GetComponent<AIDestinationSetter>().target = player;
        }
        else if (useAI)
        {
            GetComponent<AIDestinationSetter>().target = null;
        }
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
