using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSlot : MonoBehaviour
{
    public int slotNum = 1;
    [SerializeField]
    Image[] inventorySlots;
    [SerializeField]
    Image selectedSlot;

    Inventory inventory;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotNum = 1;
            updateUI(slotNum);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotNum = 2;
            updateUI(slotNum);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotNum = 3;
            updateUI(slotNum);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotNum = 4;
            updateUI(slotNum);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotNum = 5;
            updateUI(slotNum);
        }
    }
    void updateUI(int slotNumber)
    {
        Vector2 newLocation = inventorySlots[slotNumber-1].gameObject.transform.position;
        selectedSlot.transform.position = newLocation;
        inventory.currentSlot = slotNumber;
    }
}
