using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meatball : Object
{

    public override void OnPrimaryUse(PlayerInventory inventory)
    {
        inventory.ForceRemoveItem(this);
        transform.position = inventory.cameraTransform.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(inventory.cameraTransform.forward * 1000);
        
    }

    public override void OnSecondaryUse(PlayerInventory inventory)
    {
        
    }
}
