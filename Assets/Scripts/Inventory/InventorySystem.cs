using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    //public List<InventoryItem> inventory { get; private set; }
    [SerializeField] private List<InventoryItem> inventory;
    public List<InventoryItem> Inventory => inventory;
     
    //public static InventorySystem current;

    public InventorySystem()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
    public UnityAction OnInventoryChanged;

    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
        OnInventoryChanged?.Invoke();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
        }

        if (value.stackSize == 0)
        {
            inventory.Remove(value);
            m_itemDictionary.Remove(referenceData);
        }
        OnInventoryChanged?.Invoke();
    }
    /*
    private void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        //current = this;
    }

   
    public void InventoryChanged()
    {
        if (OnInventoryChanged != null)
        {
            OnInventoryChanged();
        }
}

    public void Add(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
        InventoryChanged();
    }

    public void Remove(InventoryItemData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();
        }

        if(value.stackSize == 0)
        {
            inventory.Remove(value);
            m_itemDictionary.Remove(referenceData);
        }
        InventoryChanged();
    }*/
}
