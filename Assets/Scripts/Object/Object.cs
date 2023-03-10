using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public string objectName;
    public Texture2D UITexture;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent(out Rigidbody rbTemp))
        {
            rb = rbTemp;
        } else
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnPrimaryUse(PlayerInventory inventory)
    {

    }

    public virtual void OnSecondaryUse(PlayerInventory inventory)
    {

    }

}
