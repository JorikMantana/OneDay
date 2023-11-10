using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public GameObject Prefab { get; set; }

    public InventoryItem(string name, string description, GameObject prefab)
    {
        Name = name;
        Description = description;
        Prefab = prefab;
    }
}
