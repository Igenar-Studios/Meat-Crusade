using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public Transform cameraTransform;
    public Transform groundTransform;

    private List<Object> inventoryContents = new List<Object>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.transform.position, cameraTransform.forward, out hit, 5f))
        {
            if (hit.collider.CompareTag("Object"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (inventoryContents.Count < 5)
                    {
                        Object obj = hit.collider.GetComponent<Object>();
                        inventoryContents.Add(obj);
                        obj.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Object obj = inventoryContents[0];
            obj.gameObject.SetActive(true);
            //spawn it in front of player
            inventoryContents.Remove(obj);
        }
    }
}
