using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public Transform cameraTransform;
    public Transform dropTransform;

    public PlayerController player;

    public Text hotbarText;
    public Canvas canvas;

    public Texture2D selected;

    private List<Object> inventoryContents = new List<Object>();

    private int selectedItem = 0;

    private ThrowMeatballObjective meatballObjective = null;
    private ThrowCanObjective canObjective = null;

    public LevelController levelController;

    private Outline prevOutline = null;
    // Start is called before the first frame update
    void Start()
    {
        if (levelController.TryGetComponent<ThrowMeatballObjective>(out ThrowMeatballObjective objective))
        {
            meatballObjective = objective;
        }

        if (levelController.TryGetComponent<ThrowCanObjective>(out ThrowCanObjective objective2))
        {
            canObjective = objective2;
        }
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
            if (hit.collider.GetComponent<Object>() != null)
            {
                if (hit.collider.TryGetComponent<Outline>(out Outline outline))
                {
                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    prevOutline = outline;
                }
                if (Input.GetKeyDown(KeyCode.F) && player.acceptingInput)
                {
                    AddItem(hit.collider.GetComponent<Object>());
                }
            }
        } 
        else 
        {
            if (prevOutline != null)
            {
                prevOutline.OutlineMode = Outline.Mode.SilhouetteOnly;
                prevOutline = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.G) && player.acceptingInput)
        {
            DropItem(inventoryContents[selectedItem]);
        } 
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedItem >= inventoryContents.Count - 1)
            {
                selectedItem = 0;
            } else
            {
                selectedItem++;
            }
            
        } 
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedItem <= 0)
            {
                selectedItem = inventoryContents.Count - 1;
            }
            else
            {
                selectedItem--;
            }
        }

        if (Input.GetMouseButtonDown(0) && inventoryContents.Count > 0 && player.acceptingInput)
        {
            Object obj = inventoryContents[selectedItem];
            if (meatballObjective != null && canObjective != null)
            {
                checkObjectiveMeatball(obj);
                checkObjectiveCan(obj);
            }
            obj.OnPrimaryUse(this);
            selectedItem = 0;
        }
        else if (Input.GetMouseButtonDown(1) && inventoryContents.Count > 0 && player.acceptingInput)
        {
            Object obj = inventoryContents[selectedItem];
            if (canObjective != null)
            {
                checkObjectiveCan(obj);
            }
            obj.OnSecondaryUse(this);
            selectedItem = 0;
        }
    }

    void OnGUI()
    {
        for (int i = 0; i < inventoryContents.Count; i++)
        {
            Object obj = inventoryContents[i];
            Texture2D texture = obj.UITexture;
            Graphics.DrawTexture(new Rect((100 * (i + 1)) + 25, Screen.height - 100, 100, 100), texture);
            if (i == selectedItem && inventoryContents.Count > 0)
            {
                Graphics.DrawTexture(new Rect((100 * (i + 1)) + 5, Screen.height - 20, 16, 16), selected);
            }
        }
    }

    void checkObjectiveMeatball(Object obj)
    {
        if (meatballObjective != null && obj.GetComponent<Meatball>() != null)
        {
            meatballObjective.thrown = true;
        }
    }

    void checkObjectiveCan(Object obj)
    {
        if (canObjective != null && obj.GetComponent<Can>() != null)
        {
            canObjective.thrown = true;
        }
    }

}
