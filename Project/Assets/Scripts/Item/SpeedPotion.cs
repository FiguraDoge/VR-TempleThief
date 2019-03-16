using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpeedPotion", menuName = "Inventory/Potion/SpeedPotion")]
public class SpeedPotion : Item
{
    public int speedIncrease;

    // Update is called once per frame
    public override void Use()
    {
        base.Use();
        Debug.Log("Gotta go fast!");
        RightController.instance.speedBuff += speedIncrease;
        RightController.instance.speedBuffTime = 4f;
        RemoveFromInventory();
    }
}
