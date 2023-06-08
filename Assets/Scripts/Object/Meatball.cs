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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Entity>(out Entity entity))
        {
            gameObject.SetActive(false);
            entity.health -= 500;
        }
    }

}
