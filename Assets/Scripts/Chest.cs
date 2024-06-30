using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    Sprite openChest;

    [SerializeField]
    GameObject contents;

    BoxCollider2D cl;
    Rigidbody2D rb;
    SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        cl.enabled = false;
        rb.simulated = false;
        render.sprite = openChest;
        Instantiate(contents, transform.position, Quaternion.identity);
    }
}
