using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public Transform cameraTransform;

    public Text hotbarText;

    private List<Object> inventoryContents = new List<Object>();

    private int selectedItem = 0;

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
                        RefreshGUI();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Object obj = inventoryContents[selectedItem];
            obj.gameObject.SetActive(true);
            obj.transform.position = cameraTransform.position;
            obj.GetComponent<Rigidbody>().AddForce((cameraTransform.forward  * 5));
            inventoryContents.Remove(obj);
            RefreshGUI();
        }
    }

    void RefreshGUI()
    {
        string str = "Hotbar: \n";
        for (int i = 0; i < inventoryContents.Count; i++)
        {
            str += i + ": " + inventoryContents[i].objectName;
            if (selectedItem == i)
            {
                str += " SELECTED \n";
            } else
            {
                str += "\n";
            }
        }
        Debug.Log(str);
        hotbarText.text = str;
    }

}
