using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour,IInteractable
{
    public ItemData data;

    public void Interact()
    {
        Debug.Log("interaction item : " + data.name);
        InventoryManager.instance.AddItem(data);
        Destroy(gameObject);
    }
}
