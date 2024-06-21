using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    Health health;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
        
    }
    public void heal()
    {
        health.UpdateHealth(2);
        
    }
    public void healEffect()
    {
        //add healing VFX here later
    }
}
