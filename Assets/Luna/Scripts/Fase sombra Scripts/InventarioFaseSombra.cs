using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventarioFaseSombra : MonoBehaviour
{
    public static InventarioFaseSombra Instance;

    public List<Item> items = new List<Item>();

    public GameObject[] itemIcons;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(int id, string name)
    {
        items.Add(new Item(name, id));

        if (id >= 0 && id < itemIcons.Length)
        {
            itemIcons[id].SetActive(true);
        }
    }

    public bool TemItem(int id)
    {
        foreach (Item item in items)
        {
            if (item.id == id)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int id)
    {
        Item itemParaRemover = null;

        foreach (Item item in items)
        {
            if (item.id == id)
            {
                itemParaRemover = item;
                break;
            }
        }

        if (itemParaRemover != null)
        {
            items.Remove(itemParaRemover);
            if (id >= 0 && id < itemIcons.Length)
            {
                itemIcons[id].SetActive(false);
            }
        }

    }



}

public class Item
{
    public string name;
    public int id;

    public Item(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}
