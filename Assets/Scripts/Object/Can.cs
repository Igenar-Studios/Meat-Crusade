using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : Object
{

    public GameObject flamePrefab;

    public float throwDelay = 4f;
    public float tossDelay = 2.5f;

    public override void OnPrimaryUse(PlayerInventory inventory)
    {
        inventory.ForceRemoveItem(this);
        transform.position = inventory.cameraTransform.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(inventory.cameraTransform.forward * 1000);
        Invoke("Ignite", throwDelay);
    }

    public override void OnSecondaryUse(PlayerInventory inventory)
    {
        inventory.ForceRemoveItem(this);
        transform.position = inventory.cameraTransform.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(inventory.cameraTransform.forward * 10);
        Invoke("Ignite", tossDelay);
    }

    private void Ignite()
    {
        GameObject fire = Instantiate(flamePrefab, null);
        fire.transform.position = transform.position;
        gameObject.SetActive(false);
    }

}
