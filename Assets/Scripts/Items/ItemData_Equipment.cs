using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Throwable,
    Shield,
    Consumable,
}

[CreateAssetMenu(fileName = "New Equipment Item", menuName = "Data/Items/Equipment")]

public class ItemData_Equipment : ItemData
{
    public EquipmentType equipmentType;
    public ItemEffect[] effects;

    private int descriptionLength;

    [Header("Skill required")]	

    public string requiredSkill;

    [Header("Major stats")]
    public int health;
    public int mana;
    public int stamina;


    [Header("Offensive stats")]

    public int damage;
    public int attackSpeed;
    public int critChance;


    [Header("Craft requirements")]
    public List<InventoryItem> craftingMaterials;

    public void ItemEffect()
    {
        foreach (ItemEffect effect in effects)
        {
            effect.ExecuteItemEffect();
        }
    }

    public void AddModifiers()
    {
        // Aqui es donde se tiene que settear las stats segun lo que reciba del item en cuestion dentro de las DATAS 
    }

    public void RemoveModifiers()
    {
        // Aqui es donde se tiene que remover las stats segun lo que reciba del item en cuestion dentro de las DATAS
    }

    public override string GetDescription()
    {   
        sb.Length = 0;
        descriptionLength = 0;
        
        AddItemDescription(health, "Health");
        AddItemDescription(mana, "Mana");
        AddItemDescription(stamina, "Stamina");
        AddItemDescription(damage, "Damage");
        AddItemDescription(attackSpeed, "Attack Speed");
        AddItemDescription(critChance, "Crit Chance");

        if(descriptionLength < 5)
        {   
            for(int i = 0; i < 5-descriptionLength; i++)
            {
                sb.AppendLine();
                sb.Append("");
            }
            
        }
        
        return sb.ToString();
    }

    private void AddItemDescription(int _value,string _name)
    {
        if (_value != 0)
        {
            if(sb.Length > 0)
            {
                sb.AppendLine();
            }

            if(_value > 0)
            {
                sb.Append("+" + _value + " " + _name);
            }
            descriptionLength++;
        }
    }


}
