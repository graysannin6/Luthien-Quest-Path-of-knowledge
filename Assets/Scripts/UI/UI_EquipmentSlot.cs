using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipmentSlot : UI_ItemSlot
{
    public EquipmentType slotType;

    private void OnValidate()
    {
        gameObject.name = "Equipment slot -" + slotType.ToString();
    }

    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (item == null || item.data == null)
        {
            return;
        }
        Inventory.instance.UnequipItem(item.data as ItemData_Equipment);  
        Inventory.instance.AddItem(item.data as ItemData_Equipment);

        ui.itemToolTip.HideToolTip();

        CleanUpSlot();
    }
}
