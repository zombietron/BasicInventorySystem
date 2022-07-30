using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualInventoryManager : MonoBehaviour
{
    private static VisualInventoryManager instance;

    public static VisualInventoryManager Instance
    {
        private set 
        {
            if (instance != null)
            {
                Debug.LogWarning("Tried to spawn addition instance of VISUAL MANAGER, Destroyed");
                Destroy(value.gameObject);
                return;
            }
            else
                instance = value;
        }
        get { return instance; }
    }

   GameObject[,] inventoryDisp;
   [SerializeField] GameObject[] rows;
   [SerializeField] float paddingScale= 5.0f;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        inventoryDisp = new GameObject[4,6];
        InitDisplayArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UpdateDisplayArray(InventoryManager.Instance.Inventory);
    }

    public void InitDisplayArray()
    {
        int ind = 0;
        Debug.Log(inventoryDisp.Length/rows.Length);
        for(int r = 0; r < 4; r++)
        {
            for (int i = 0; i < inventoryDisp.Length/rows.Length; i++)
            {
                Button b = rows[r].transform.GetChild(i).GetComponent<Button>();
                b.name = $"Button: {ind+1}";
                TMP_Text t = b.gameObject.transform.GetComponentInChildren<TMP_Text>();
                t.text = $"{ind + 1}";
                t.enableAutoSizing = true;
                t.fontSizeMin = 2;
                t.fontSizeMax = 36;
                t.margin = Vector4.one * paddingScale ;
                inventoryDisp[r, i] = b.gameObject;
                ind++;
            }
        }
    }

    public void UpdateDisplayArray(Item_SO[] arr)
    {
        int indexer = 0;
        if(arr.Length != inventoryDisp.Length)
        {
            Debug.LogWarning($"These inventory arrays do not match provided array is length: {arr.Length} and Display Array is length: {inventoryDisp.Length}");
            return;
        }

        for(int i = 0; i< rows.Length; i++)
        {
            for(int j = 0; j< inventoryDisp.Length/rows.Length; j++)
            {
                if (arr[indexer] != null)
                {
                    Item_SO item = arr[indexer];
                    var go = inventoryDisp[i, j];
                    go.GetComponent<Image>().sprite = item.icon;
                    inventoryDisp[i, j].GetComponent<Image>().sprite = item.icon;
                }
             

                indexer++;
            }
        }

    }
    
}
