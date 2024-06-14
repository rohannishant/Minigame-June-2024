using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    bool useAI;
    [SerializeField]
    float knockback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
