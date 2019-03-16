using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HealthPotion", menuName = "Inventory/Potion/HealthPotion")]
public class HealthPotion : Item
{
    public int recovery;

    public override void Use()
    {
        base.Use();
        if (!HP.instance.fullHP())
        {
            // Increase the health when HP is not full
            HP.instance.modifyHP(recovery);
            // Remove it from the inventory
            RemoveFromInventory();
        }
        else
        {
            Debug.Log("Full health!!! You do not need heal now!");
        }
    }
}
