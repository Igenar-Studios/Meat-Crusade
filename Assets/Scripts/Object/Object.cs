using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    public string objectName;
    public Texture2D UITexture;

    Rigidbody rb;

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

    public void OnUse()    {

    }

}
