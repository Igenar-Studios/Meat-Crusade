using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public Transform cameraTransform;
    public Transform dropTransform;

    public Text hotbarText;
    public Canvas canvas;

    public Texture2D selected;

    private List<Object> inventoryContents = new List<Object>();

    private int selectedItem = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddItem(Object obj)
    {
        if (inventoryContents.Count < 5)
        {
            inventoryContents.Add(obj);
            obj.gameObject.SetActive(false);
        }
    }

    public void DropItem(Object obj)
    {
        if (!inventoryContents.Contains(obj)) return;
        obj.gameObject.SetActive(true);
        obj.transform.position = dropTransform.position;
        obj.rb.velocity = Vector3.zero;
        inventoryContents.Remove(obj);
    }

    public void ForceRemoveItem(Object obj)
    {
        if (!inventoryContents.Contains(obj)) return;
        obj.gameObject.SetActive(true);
        inventoryContents.Remove(obj);
    }

    public List<Object> GetContents()
    {
        return inventoryContents;
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
                    AddItem(hit.collider.GetComponent<Object>());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropItem(inventoryContents[selectedItem]);
        }

        if (Input.GetMouseButtonDown(0) && inventoryContents.Count > 0)
        {
            Object obj = inventoryContents[selectedItem];
            obj.OnPrimaryUse(this);
        }
        else if (Input.GetMouseButtonDown(1) && inventoryContents.Count > 0)
        {
            Object obj = inventoryContents[selectedItem];
            obj.OnSecondaryUse(this);
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < inventoryContents.Count; i++)
        {
            Object obj = inventoryContents[i];
            Texture2D texture = obj.UITexture;
            Graphics.DrawTexture(new Rect((50 * (i + 1)) + 100, Screen.height - 100, 100, 100), texture);
            if (i == selectedItem && inventoryContents.Count > 0)
            {
                Graphics.DrawTexture(new Rect((50 * (i + 1)) + 80, Screen.height - 20, 16, 16), selected);
            }
        }
    }

}
