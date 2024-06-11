using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Rigidbody2D rb;

    Vector2 move;

    [SerializeField]
    int health = 10;
    [SerializeField]
    Sprite healthFull, healthHalf, healthEmpty;
    [SerializeField]
    Image[] healthImages;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if(Input.GetKeyDown(KeyCode.G))
        {
            UpdateHealth(-1);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            UpdateHealth(1);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    public void UpdateHealth(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, 10);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        int fullHearts = Mathf.FloorToInt(health / 2f);
        for (int i = 0; i < fullHearts; i++)
        {
            healthImages[i].sprite = healthFull;
        }
        if (health % 2 > 0)
        {
            healthImages[fullHearts].sprite = healthHalf;
            fullHearts++;
        }
        for (int i = fullHearts; i < 5; i++)
        {
            healthImages[i].sprite = healthEmpty;
        }
    }
}
