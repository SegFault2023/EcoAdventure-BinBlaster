using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private Sprite sprite;

    private bool can_be_picked = false;

    private InventoryManager inventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if(can_be_picked == true && Input.GetKeyDown(KeyCode.X))
        {
            Boolean is_added = inventoryManager.AddItem(itemName, sprite, this.tag);

            if(is_added) { Destroy(gameObject, 0.1f); }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_be_picked = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_be_picked = false;
        }
    }


}