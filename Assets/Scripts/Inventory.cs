using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;
    [SerializeField]
    private MenuManager menuManager;

    public List<Item> allItems;

#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif
    void Awake()
    {
        FreshSlot();
    }

    void OnEnable() 
    {
        FreshSlot();
    }

    void Start()
    {
        List<string> itemNames = GameManager.Instance.itemList;


        items = new List<Item>();

        foreach (Item item in allItems)
        {
            if (itemNames.Contains(item.name))
            {
                items.Add(item);
            }
        }

        FreshSlot();
    }


    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(Item Item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(Item);
            FreshSlot();
        }
        else
        {
            Debug.Log("슬롯 꽉참");
        }
    }
    
}
