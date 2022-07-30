using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (InventoryManager.Instance.AddItem(gameObject))
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
                Debug.LogWarning($"Inventory full unable to add: {gameObject.GetComponent<Item>().definition.name}");
            }
        }
    }
}
