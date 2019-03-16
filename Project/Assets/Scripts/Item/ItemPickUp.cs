using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Pick up" + item.name);

        // Add to inventory
        bool wasPickUp = Inventory.instance.Add(item);
        if (wasPickUp)
        {
            EnemyTrigger trigger = this.gameObject.GetComponent<EnemyTrigger>();
            if (trigger != null)
            {
                trigger.trigger();
            }
            Destroy(this.gameObject);
        }
    }
}
