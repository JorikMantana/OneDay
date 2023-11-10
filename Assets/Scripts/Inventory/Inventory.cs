using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> Items = new();

    /// <summary>
    /// Data.inventory = item
    /// Добавление предмета в инвентарь
    /// </summary>
    /// <param name="item">Предмет, который добовляем</param>
    public void AddItem(InventoryItem item)
    {
        if(item == null)
        {
            Debug.LogError("Item can't be null!");
            return;
        }
        Items.Add(item);
    }

    /// <summary>
    /// Удаление предмета из инвентаря
    /// </summary>
    /// <param name="itemId">index предмета</param>
    public void RemoveItem(int itemId)
    {
        if(itemId < 0)
        {
            Debug.LogError("itemId < 0");
            return;
        }

        Items.RemoveAt(itemId);
    }

    /// <summary>
    /// Получение конкретного предмета из инвентаря
    /// </summary>
    /// <param name="itemId">index предмета</param>
    /// <returns>Предмет</returns>
    public InventoryItem SelectItem(int itemId)
    {
        if (itemId < 0)
        {
            Debug.LogError("itemId < 0");
            return null;
        }

        return Items[itemId];
    }

    public List<InventoryItem> GetAll()
    {
        return Items;
    }
}
