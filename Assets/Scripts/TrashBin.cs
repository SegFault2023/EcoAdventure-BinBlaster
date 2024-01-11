using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    Animator anim;

    private Boolean can_get_trash = false;
    private int numberOfTrashes = 0;


    [SerializeField]
    private int maxTrashLimit = 4;

    private InventoryManager inventoryManager;
    public ScoreManager scoreManager;
    private GameObject selectedBin;

    [SerializeField]
    public float swapDelayInSeconds = 0.6f;

   


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(can_get_trash && Input.GetKeyDown(KeyCode.X) && (numberOfTrashes < maxTrashLimit))
        {
            int slotToBeRemoved = inventoryManager.getSelectedIndex();
            anim.SetBool("ButtonPressed", true);

            if(slotToBeRemoved != -1)
            {
                if(inventoryManager.compareTrashBinTags(this.tag, slotToBeRemoved))
                {
                    inventoryManager.RemoveItem(slotToBeRemoved);
                    numberOfTrashes++;

                    scoreManager.incrementScore();
                }

                else
                {
                    if (inventoryManager.itemSlot[slotToBeRemoved].isFull)
                    {
                        scoreManager.decrementScore();
                    }
                }
            }

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_get_trash = true;
            
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            can_get_trash = false;
        }
    }



}
