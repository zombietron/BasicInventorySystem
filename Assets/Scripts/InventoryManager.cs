using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //turn the inventory manager into an accessible static instance
    // if instance already exists destroy the instance attempting to be created. 
    //instance is initialized in Awake

    private static InventoryManager instance;

    public static InventoryManager Instance
    {
        private set 
        {
            if (instance != null)
            {
                Debug.LogWarning($"Additional instance of {instance} was attempted to spawn. Destroying");
                Destroy(value.gameObject);
                return;
            }
            else
                instance = value;
                
        }

        get { return instance; }
    }

    Item_SO[] inventory;

    public Item_SO[] Inventory
    {
        get { return inventory; }
    }

    [SerializeField] GameObject inventoryScreen;
    bool inventoryActive = false;

    //variables for Debugging your work (Click DEBUG Boolean in inspector to make it run)

    
    [Tooltip("Click me to enable Debugging of inventory")] 
    public bool debug = false;
    public Item testItem;
    int clickCount = 0;


    private void Awake()
    {
        Instance = this;

        inventory = new Item_SO[24];
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryScreen.SetActive(inventoryActive);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryActive = !inventoryActive;
            inventoryScreen.SetActive(inventoryActive);
        }


        /**
         * DEBUGGING SEGMENT USE THIS IF YOU ARE DEBUGGING INVENTORY STUFF
         * 
         * 
         * 
         */
        if (debug)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject go;
                if (testItem != null)
                {
                    go = testItem.gameObject;
                    Debug.Log("test item isn't null;");
                }
                else
                {
                    go = new GameObject();
                    Debug.Log("test item is null;");
                }

                go.name = "New Object: " + clickCount.ToString();
                clickCount++;
                bool wasAdded = AddItem(go);

                if (wasAdded) { Debug.Log("Item Added"); }
                else
                    Debug.Log("Inventory is Full;");

            }
        

            if (Input.GetMouseButtonDown(1))
            {
                DebugArrayContents();
            }
        }
      

    }

    //Add GameObject to inventory in an empty space
    // if 
    public bool AddItem(GameObject obj)
    {
        bool added = false;
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i]==null)
            {
                added = !added;
                Item_SO addItem = obj.GetComponent<Item>().definition;
                inventory[i] = addItem;
                Debug.Log($"Added Object: {addItem.name} at:{i}");
                if (inventoryScreen.activeSelf)
                {
                    VisualInventoryManager.Instance.UpdateDisplayArray(inventory);
                }
                break;
            }

        }

        return added;
    }


    // prints contents of the inventory array, currently tied to the DEBUG boolean, if checked right click will call this function
    public void DebugArrayContents()
    {
        int index = 0;
        foreach (Item_SO g in inventory)
        {
            
            if (g != null)
            {
                Debug.Log($"Index: {index} contains: {g.name}");
            }
            else
                Debug.Log($"Index: {index} is null");

            index++;

        }
    }

}
