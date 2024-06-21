using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    public void heal()
    {
        player.UpdateHealth(2);
        
    }
    public void healEffect()
    {
        //add healing VFX here later
    }
}
