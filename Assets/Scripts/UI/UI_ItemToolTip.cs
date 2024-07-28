using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ItemToolTip : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemTypeText;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private int defaultFontSize = 32;


    void Start()
    {
        
    }

    public void ShowToolTip(ItemData_Equipment _item)
    {   
        if (_item == null)
        {
            return;
        }
        itemNameText.text = _item.itemName;
        itemTypeText.text = _item.itemType.ToString();
        itemDescription.text = _item.GetDescription();

        if(itemNameText.text.Length > 13)
        {
            itemNameText.fontSize = itemNameText.fontSize * .7f;
        }
        else
        {
            itemNameText.fontSize = defaultFontSize;
        }

        gameObject.SetActive(true);
        
    }

    public void HideToolTip() 
    {   
        itemNameText.fontSize = defaultFontSize;
        gameObject.SetActive(false);

    }
    
}
