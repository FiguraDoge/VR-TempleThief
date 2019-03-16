using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Treasure", menuName = "Inventory/Treasure/Dagger")]
public class Treasure : Item
{
    public int MAXHP_UP;

    // Update is called once per frame
    public override void Use()
    {
        base.Use();
        HP.instance.increaseMAXHP(MAXHP_UP);
        RemoveFromInventory();
    }
}
