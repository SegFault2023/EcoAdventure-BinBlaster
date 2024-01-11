using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ItemSlot : MonoBehaviour
{
    //=====ITEM DATA=====//
    public string itemName;
    public bool isFull;


    //====ITEM SLOT====//
    public GameObject selectedShader;
    public bool thisItemSelected;
    
   

    [SerializeField]
    private Image itemImage;

    public String getItemImageTag() {  return itemImage.tag; }

  

    public void AddItem(string itemName, Sprite itemSprite, string itemTag)
    {
        this.itemName = itemName;
        isFull = true;
    
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        itemImage.tag = itemTag;
    }

    public void RemoveItem()
    {
        isFull = false;

        itemImage.enabled = false;
        itemImage.tag = "Untagged";
    }
}