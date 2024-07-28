using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemObject : MonoBehaviour
{

    [SerializeField] private ItemData itemData;

    public void OnValidate()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.icon;
        gameObject.name = "Item object - " + itemData.itemName;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.GetComponent<MouvementTestInventory>() != null)
        {   
            Debug.Log("Item picked up" + itemData.itemName);
            Inventory.instance.AddItem(itemData);
            Destroy(gameObject);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
{
    if (itemData == null)
    {
        Debug.LogError("itemData is null for " + gameObject.name);
        return;
    }

    if (Inventory.instance == null)
    {
        Debug.LogError("Inventory.instance is null");
        return;
    }

    if (collision.GetComponent<MouvementTestInventory>() != null)
    {
        Debug.Log("Item picked up: " + itemData.itemName);
        //Inventory.instance.AddItem(itemData);
        Destroy(gameObject);
    }
    else
    {
        Debug.Log("Collision with object without MouvementTestInventory component");
    }
}*/
}
