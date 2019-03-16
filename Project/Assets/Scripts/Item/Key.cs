using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Key")]
public class Key : Item
{
    public GameObject gate;
    public LockGate lockgate;

    public override void Use()
    {
        base.Use();
        lockgate = gate.GetComponent<LockGate>(); 
        // use key to the gate
        lockgate.useKey();
    }
}
