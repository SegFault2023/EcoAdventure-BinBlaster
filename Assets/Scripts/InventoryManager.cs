using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;

    private Boolean isAnItemSelected = false;
    private float shaderSelectedTime;

    [SerializeField]
    private int slotActiveTime = 6;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(KeyCode.Alpha1);
            shaderSelectedTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(KeyCode.Alpha2);
            shaderSelectedTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(KeyCode.Alpha3);
            shaderSelectedTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(KeyCode.Alpha4);
            shaderSelectedTime = Time.time;
        }

        if (isAnItemSelected && Time.time >= shaderSelectedTime + slotActiveTime)
        {
            DeselectAllSlots();
        }
    }

    public Boolean compareTrashBinTags(String binTag, int index)
    {
        if (itemSlot[index].getItemImageTag() == "TrashType1" && binTag == "BinType1") { return true; }
        else if (itemSlot[index].getItemImageTag() == "TrashType2" && binTag == "BinType2") { return true; }
        else if (itemSlot[index].getItemImageTag() == "TrashType3" && binTag == "BinType3") { return true; }
        else if (itemSlot[index].getItemImageTag() == "TrashType4" && binTag == "BinType4") { return true; }

        return false;
    }

    public int getSelectedIndex()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemSelected)
            {
                return i;
            }
        }
        return -1;
    }


    public Boolean AddItem(string itemName, Sprite itemSprite, String itemTag)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemSprite, itemTag);
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(int index)
    {
        itemSlot[index].RemoveItem();
    }

    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
            isAnItemSelected = false;
        }
    }

    public void SelectSlot(KeyCode key)
    {
        int indexToBeSelected = 0;
        
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].thisItemSelected)
            {

                itemSlot[i].selectedShader.SetActive(false);
                itemSlot[i].thisItemSelected = false;
                break;
            }
        }

        if (key == KeyCode.Alpha1)
        { 
            indexToBeSelected = 0;       
        }

        else if (key == KeyCode.Alpha2)
        {
            indexToBeSelected = 1;          
        }

        else if (key == KeyCode.Alpha3)
        {
            indexToBeSelected = 2;
        }

        else if (key == KeyCode.Alpha4)
        {
            indexToBeSelected = 3;
        }


        itemSlot[indexToBeSelected].selectedShader.SetActive(true);
        itemSlot[indexToBeSelected].thisItemSelected = true;
        isAnItemSelected = true;
        
    }

}