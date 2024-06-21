using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Inventory inventory;
    public Transform slotOne;
    public Transform slotTwo;
    public Transform slotThree;
    public Transform slotFour;
    public Transform slotFive;
    public GameObject healthPotionPrefab;
    Dictionary<string, GameObject> itemMap = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        itemMap.Add("HealthPotionIcon(Clone)", healthPotionPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventory.currentSlot == 1)
            {
                DropItem(slotOne);
            }
            if (inventory.currentSlot == 2)
            {
                DropItem(slotTwo);
            }
            if (inventory.currentSlot == 3)
            {
                DropItem(slotThree);
            }
            if (inventory.currentSlot == 4)
            {
                DropItem(slotFour);
            }
            if (inventory.currentSlot == 5)
            {
                DropItem(slotFive);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inventory.currentSlot == 1)
            {
                UseItem(slotOne);
            }
            if (inventory.currentSlot == 2)
            {
                UseItem(slotTwo);
            }
            if (inventory.currentSlot == 3)
            {
                UseItem(slotThree);
            }
            if (inventory.currentSlot == 4)
            {
                UseItem(slotFour);
            }
            if (inventory.currentSlot == 5)
            {
                UseItem(slotFive);
            }
        }
    }
    void UseItem(Transform slotTransform)
    {
        inventory.isFull[inventory.currentSlot-1] = false;
        int childNum = slotTransform.childCount;
        for (int i = 0; i < childNum; i++)
        {
            HealthPotion healthPotion = slotTransform.GetChild(i).gameObject.GetComponent<HealthPotion>();
            if(healthPotion == null)
            {
                Debug.Log("whyyyyy");
            }
            healthPotion.heal();
            healthPotion.healEffect();
            DestroyImmediate(slotTransform.GetChild(i).gameObject);
        }
    }
    void DropItem(Transform slotTransform)
    {
        inventory.isFull[inventory.currentSlot - 1] = false;
        int childNum = slotTransform.childCount;
        for (int i = 0; i < childNum; i++)
        {    
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector2 pos = new Vector2(player.transform.position.x, player.transform.position.y+1);
            Instantiate(itemMap[slotTransform.GetChild(i).name.ToString()], pos, Quaternion.identity);
            DestroyImmediate(slotTransform.GetChild(i).gameObject);
        }
    }
}
