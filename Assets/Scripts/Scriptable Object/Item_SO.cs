using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemPickup")]
public class Item_SO : ScriptableObject
{
    public enum ItemType { potion, weapon, armor, money };
    public string name;
    public Sprite icon;
    public ItemType itemType;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

