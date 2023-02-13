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
            Object obj = inventoryContents[selectedItem];
            obj.gameObject.SetActive(true);
            obj.transform.position = dropTransform.position;
            inventoryContents.Remove(obj);
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < inventoryContents.Count; i++)
        {
            Object obj = inventoryContents[i];
            Texture2D texture = obj.UITexture;
            Graphics.DrawTexture(new Rect((50 * (i + 1)) + 100, Screen.height - 100, 100, 100), texture);
            if (i == selectedItem)
            {
                Graphics.DrawTexture(new Rect((50 * (i + 1)) + 80, Screen.height - 20, 16, 16), selected);
            }
        }
        hotbarText.text = "Hotbar";
    }

}
